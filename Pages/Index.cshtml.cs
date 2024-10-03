using inz.Data;
using inz.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace inz.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public List<Trip> TripsLastMinute { get; set; }
        public List<Trip> Trips { get; set; }
        public List<City> Cities { get; set; }
        public List<Country> Countries { get; set; }
        public List<Airport> Airports { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? City { get; set; } 

        [BindProperty(SupportsGet = true)]
        public string? Country { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Duration { get; set; }

        public int DaysDuration1 { get; set; }
        public int DaysDuration2 { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateOnly DepartureDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateOnly ArrivalDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Airport { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public int AdultNumber { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public int ChildNumber { get; set; }
        [BindProperty]
        public Trip trip { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            TripsLastMinute = await _context.trips.Where(t => t.IsLastMinute == true).Include(h => h.Hotel).Include(f => f.FromAirport).Take(4).ToListAsync();            
            Trips = new List<Trip>();
            Countries = await _context.countries.ToListAsync();

            Cities = await _context.cities.ToListAsync();

            Airports = await _context.airports.Where(a => a.City.Country.Name.Equals("Polska")).ToListAsync();
            switch (Duration)
            {
                case "3Dni":
                    DaysDuration2 = 3;
                    break;
                case "4-6Dni":
                    DaysDuration1 = 4;
                    DaysDuration2 = 6;
                    break;
                case "7-9Dni":
                    DaysDuration1 = 7;
                    DaysDuration2 = 9;
                    break;
                case "10-13Dni":
                    DaysDuration1 = 10;
                    DaysDuration2 = 13;
                    break;
                case "14-16Dni":
                    DaysDuration1 = 14;
                    DaysDuration2 = 16;
                    break;
                case "17Dni":
                    DaysDuration2 = 17;
                    break;
                case "dokladnaData":
                    DaysDuration2 = (ArrivalDate.DayNumber - DepartureDate.DayNumber);
                    break;
            }

            if (Country == "krajGdziekolwiek")
            {
                if (City == "miastoGdziekolwiek")
                {
                    if (DaysDuration2 == 3)
                    {
                        if (Airport == "lotniskoGdziekolwiek")
                        {
                            Trips = await _context.trips.Where(t => (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) <= DaysDuration2 && t.DepartureDate == DepartureDate)
                                .Include(h => h.Hotel).Include(f => f.FromAirport).ToListAsync();
                        }
                        else
                        {
                            Trips = await _context.trips.Where(t => (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) <= DaysDuration2 && t.DepartureDate == DepartureDate && t.FromAirport.Name == Airport)
                                .Include(h => h.Hotel).Include(f => f.FromAirport).ToListAsync();
                        }
                    }
                    else
                    {
                        if(DaysDuration2 == 17)
                        {
                            if (Airport == "lotniskoGdziekolwiek")
                            {
                                Trips = await _context.trips.Where(t => (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) >= DaysDuration2 && t.DepartureDate == DepartureDate)
                                    .Include(h => h.Hotel).Include(f => f.FromAirport).ToListAsync();
                            }
                            else
                            {
                                Trips = await _context.trips.Where(t => (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) >= DaysDuration2 && t.DepartureDate == DepartureDate && t.FromAirport.Name == Airport)
                                    .Include(h => h.Hotel).Include(f => f.FromAirport).ToListAsync();
                            }
                        } else
                        {
                            if (Duration == "dokladnaData")
                            {
                                if (Airport == "lotniskoGdziekolwiek")
                                {
                                    Trips = await _context.trips.Where(t => (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) <= DaysDuration2 && t.DepartureDate >= DepartureDate && t.ArrivalDate <= ArrivalDate)
                                        .Include(h => h.Hotel).Include(f => f.FromAirport).ToListAsync();
                                }
                                else
                                {
                                    Trips = await _context.trips.Where(t => (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) <= DaysDuration2 && t.DepartureDate >= DepartureDate && t.ArrivalDate <= ArrivalDate && t.FromAirport.Name == Airport)
                                        .Include(h => h.Hotel).Include(f => f.FromAirport).ToListAsync();
                                }
                            } else
                            {
                                if (Airport == "lotniskoGdziekolwiek")
                                {
                                    Trips = await _context.trips.Where(t => (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) >= DaysDuration1 && (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) <= DaysDuration2 && t.DepartureDate == DepartureDate)
                                        .Include(h => h.Hotel).Include(f => f.FromAirport).ToListAsync();
                                }
                                else
                                {
                                    Trips = await _context.trips.Where(t => (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) >= DaysDuration1 && (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) <= DaysDuration2 && t.DepartureDate == DepartureDate && t.FromAirport.Name == Airport)
                                        .Include(h => h.Hotel).Include(f => f.FromAirport).ToListAsync();
                                }
                            }
                        } 
                    }
                }
                else
                {
                    if (DaysDuration2 == 3)
                    {
                        if (Airport == "lotniskoGdziekolwiek")
                        {
                            Trips = await _context.trips.Where(t => (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) <= DaysDuration2 && t.DepartureDate == DepartureDate && t.Hotel.City.Name == City)
                                .Include(h => h.Hotel).Include(f => f.FromAirport).ToListAsync();
                        }
                        else
                        {
                            Trips = await _context.trips.Where(t => (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) <= DaysDuration2 && t.DepartureDate == DepartureDate && t.FromAirport.Name == Airport && t.Hotel.City.Name == City)
                                .Include(h => h.Hotel).Include(f => f.FromAirport).ToListAsync();
                        }
                    }
                    else
                    {
                        if(DaysDuration2 == 17)
                        {
                            if (Airport == "lotniskoGdziekolwiek")
                            {
                                Trips = await _context.trips.Where(t => (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) >= DaysDuration2 && t.DepartureDate == DepartureDate && t.Hotel.City.Name == City)
                                    .Include(h => h.Hotel).Include(f => f.FromAirport).ToListAsync();
                            }
                            else
                            {
                                Trips = await _context.trips.Where(t => (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) >= DaysDuration2 && t.DepartureDate == DepartureDate && t.FromAirport.Name == Airport && t.Hotel.City.Name == City)
                                    .Include(h => h.Hotel).Include(f => f.FromAirport).ToListAsync();
                            }
                        } else
                        {
                            if (Duration == "dokladnaData")
                            {
                                if (Airport == "lotniskoGdziekolwiek")
                                {
                                    Trips = await _context.trips.Where(t => (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) <= DaysDuration2 && t.DepartureDate >= DepartureDate && t.ArrivalDate <= ArrivalDate && t.Hotel.City.Name == City)
                                        .Include(h => h.Hotel).Include(f => f.FromAirport).ToListAsync();
                                }
                                else
                                {
                                    Trips = await _context.trips.Where(t => (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) <= DaysDuration2 && t.DepartureDate >= DepartureDate && t.ArrivalDate <= ArrivalDate && t.Hotel.City.Name == City && t.FromAirport.Name == Airport)
                                        .Include(h => h.Hotel).Include(f => f.FromAirport).ToListAsync();
                                }
                            } else
                            {
                                if (Airport == "lotniskoGdziekolwiek")
                                {

                                    Trips = await _context.trips.Where(t => (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) >= DaysDuration1 && (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) <= DaysDuration2 && t.DepartureDate == DepartureDate && t.Hotel.City.Name == City)
                                        .Include(h => h.Hotel).Include(f => f.FromAirport).ToListAsync();
                                }
                                else
                                {
                                    Trips = await _context.trips.Where(t => (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) >= DaysDuration1 && (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) <= DaysDuration2 && t.DepartureDate == DepartureDate && t.FromAirport.Name == Airport && t.Hotel.City.Name == City)
                                        .Include(h => h.Hotel).Include(f => f.FromAirport).ToListAsync();
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (City == "miastoGdziekolwiek")
                {
                    if (DaysDuration2 == 3)
                    {
                        if (Airport == "lotniskoGdziekolwiek")
                        {
                            Trips = await _context.trips.Where(t => (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) <= DaysDuration2 && t.DepartureDate == DepartureDate && t.Hotel.City.Country.Name == Country)
                                .Include(h => h.Hotel).Include(f => f.FromAirport).ToListAsync();
                        }
                        else
                        {
                            Trips = await _context.trips.Where(t => (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) <= DaysDuration2 && t.DepartureDate == DepartureDate && t.FromAirport.Name == Airport && t.Hotel.City.Country.Name == Country)
                                .Include(h => h.Hotel).Include(f => f.FromAirport).ToListAsync();
                        }
                    }
                    else
                    {
                        if(DaysDuration2 == 17)
                        {
                            if (Airport == "lotniskoGdziekolwiek")
                            {
                                Trips = await _context.trips.Where(t => (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) >= DaysDuration2 && t.DepartureDate == DepartureDate && t.Hotel.City.Country.Name == Country)
                                    .Include(h => h.Hotel).Include(f => f.FromAirport).ToListAsync();
                            }
                            else
                            {
                                Trips = await _context.trips.Where(t => (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) >= DaysDuration2 && t.DepartureDate == DepartureDate && t.FromAirport.Name == Airport && t.Hotel.City.Country.Name == Country)
                                    .Include(h => h.Hotel).Include(f => f.FromAirport).ToListAsync();
                            }
                        } else
                        {
                            if (Duration == "dokladnaData")
                            {
                                if (Airport == "lotniskoGdziekolwiek")
                                {
                                    Trips = await _context.trips.Where(t => (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) <= DaysDuration2 && t.DepartureDate >= DepartureDate && t.ArrivalDate <= ArrivalDate && t.Hotel.City.Country.Name == Country)
                                        .Include(h => h.Hotel).Include(f => f.FromAirport).ToListAsync();
                                }
                                else
                                {
                                    Trips = await _context.trips.Where(t => (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) <= DaysDuration2 && t.DepartureDate >= DepartureDate && t.ArrivalDate <= ArrivalDate && t.Hotel.City.Country.Name == Country && t.FromAirport.Name == Airport)
                                        .Include(h => h.Hotel).Include(f => f.FromAirport).ToListAsync();
                                }
                            } else
                            {
                                if (Airport == "lotniskoGdziekolwiek")
                                {
                                    Trips = await _context.trips.Where(t => (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) >= DaysDuration1 && (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) <= DaysDuration2 && t.DepartureDate == DepartureDate && t.Hotel.City.Country.Name == Country)
                                        .Include(h => h.Hotel).Include(f => f.FromAirport).ToListAsync();
                                }
                                else
                                {
                                    Trips = await _context.trips.Where(t => (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) >= DaysDuration1 && (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) <= DaysDuration2 && t.DepartureDate == DepartureDate && t.FromAirport.Name == Airport && t.Hotel.City.Country.Name == Country)
                                        .Include(h => h.Hotel).Include(f => f.FromAirport).ToListAsync();
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (DaysDuration2 == 3)
                    {
                        if (Airport == "lotniskoGdziekolwiek")
                        {
                            Trips = await _context.trips.Where(t => (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) <= DaysDuration2 && t.DepartureDate == DepartureDate && t.Hotel.City.Country.Name == Country && t.Hotel.City.Name == City)
                                .Include(h => h.Hotel).Include(f => f.FromAirport).ToListAsync();
                        }
                        else
                        {
                            Trips = await _context.trips.Where(t => (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) <= DaysDuration2 && t.DepartureDate == DepartureDate && t.FromAirport.Name == Airport && t.Hotel.City.Country.Name == Country && t.Hotel.City.Name == City)
                                .Include(h => h.Hotel).Include(f => f.FromAirport).ToListAsync();
                        }
                    }
                    else
                    {
                        if(DaysDuration2 == 17)
                        {
                            if (Airport == "lotniskoGdziekolwiek")
                            {
                                Trips = await _context.trips.Where(t => (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) >= DaysDuration2 && t.DepartureDate == DepartureDate && t.Hotel.City.Country.Name == Country && t.Hotel.City.Name == City)
                                    .Include(h => h.Hotel).Include(f => f.FromAirport).ToListAsync();
                            }
                            else
                            {
                                Trips = await _context.trips.Where(t => (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) >= DaysDuration2 && t.DepartureDate == DepartureDate && t.FromAirport.Name == Airport && t.Hotel.City.Country.Name == Country && t.Hotel.City.Name == City)
                                    .Include(h => h.Hotel).Include(f => f.FromAirport).ToListAsync();
                            }
                        } else
                        {
                            if (Duration == "dokladnaData")
                            {
                                if (Airport == "lotniskoGdziekolwiek")
                                {
                                    Trips = await _context.trips.Where(t => (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) <= DaysDuration2 && t.DepartureDate >= DepartureDate && t.ArrivalDate <= ArrivalDate && t.Hotel.City.Country.Name == Country && t.Hotel.City.Name == City)
                                        .Include(h => h.Hotel).Include(f => f.FromAirport).ToListAsync();
                                }
                                else
                                {
                                    Trips = await _context.trips.Where(t => (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) <= DaysDuration2 && t.DepartureDate >= DepartureDate && t.ArrivalDate <= ArrivalDate && t.Hotel.City.Country.Name == Country && t.FromAirport.Name == Airport && t.Hotel.City.Name == City)
                                        .Include(h => h.Hotel).Include(f => f.FromAirport).ToListAsync();
                                }
                            }
                            if (Airport == "lotniskoGdziekolwiek")
                            {
                                Trips = await _context.trips.Where(t => (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) >= DaysDuration1 && (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) <= DaysDuration2 && t.DepartureDate == DepartureDate && t.Hotel.City.Country.Name == Country && t.Hotel.City.Name == City)
                                    .Include(h => h.Hotel).Include(f => f.FromAirport).ToListAsync();
                            }
                            else
                            {
                                Trips = await _context.trips.Where(t => (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) >= DaysDuration1 && (t.ArrivalDate.DayNumber - t.DepartureDate.DayNumber) <= DaysDuration2 && t.DepartureDate == DepartureDate && t.FromAirport.Name == Airport && t.Hotel.City.Country.Name == Country && t.Hotel.City.Name == City)
                                    .Include(h => h.Hotel).Include(f => f.FromAirport).ToListAsync();
                            }
                        }
                    }
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            trip = await _context.trips.Where(i => i.Id == id).FirstAsync();
            return RedirectToRoute("./Trip", new { id = trip.Id });
        }
    }
}
