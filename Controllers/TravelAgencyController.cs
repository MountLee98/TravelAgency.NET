using Biuro_podrozy_praca_inzynierska.Data;
using Biuro_podrozy_praca_inzynierska.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;

namespace Biuro_podrozy_praca_inzynierska.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TravelAgencyController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TravelAgencyController(ApplicationDbContext context)
        {
            _context = context;
        }

        //var wynik = _context.continents.Include(c => c.Countries).ToList();
        // jeżeli nie zrobisz include, to nie weźmie domyślnie elementów powiązanych
        // czyli ma listę, ale lista jest pusta
        // include pobiera wszystkie elementy z listy
        // aby można było np.
        //var xd = wynik[0].Countries[0].Name;
        // pobiera name zerowego kraju w kontynencie
        //var result = _context.continents.Find(id);


        //[HttpPost]
        //public JsonResult CreateEditContinent(Continent continent)
        //{
        //    if(continent.Id == 0)
        //    {
        //        _context.continents.Add(continent);
        //    } else
        //    {
        //        var continentInDb = _context.continents.Find(continent.Id);
        //        if(continentInDb == null)
        //        {
        //            return new JsonResult(NotFound());
        //        }
        //        continentInDb = continent;
        //    }
        //    _context.SaveChanges();
        //    return new JsonResult(Ok(continent));
        //}

        //[HttpPost]
        //public JsonResult CreateContinent(String name)
        //{
        //    if (name == "")
        //    {
        //        return new JsonResult("Can't add empty value");
        //    }
        //    else
        //    {
        //        Continent continent = new Continent(name);
        //        _context.continents.Add(continent);
        //        _context.SaveChanges();
        //        return new JsonResult(Ok(continent));
        //    }
        //}
        //[HttpPost]
        //public JsonResult CreateEditCountry(Country country)
        //{
        //    if (country.Id == 0)
        //    {
        //        _context.country.Add(country);
        //    }
        //    else
        //    {
        //        var countryInDb = _context.country.Find(country.Id);
        //        if (countryInDb == null)
        //        {
        //            return new JsonResult(NotFound());
        //        }
        //        countryInDb = country;
        //    }
        //    _context.SaveChanges();
        //    return new JsonResult(Ok(country));
        //}

        //[HttpPost]
        //public JsonResult CreateCountry(String name, String nameOfContinent)
        //{
        //    if (name == "" || nameOfContinent == "")
        //    {
        //        return new JsonResult("Can't add empty value");
        //    }
        //    else
        //    {
        //        _context.
        //        var continent = _context.continents.Where(x => x.Name == nameOfContinent).First();
        //        Country country = new Country(name, continent.Id, continent);
        //        _context.country.Add(country);
        //        _context.SaveChanges();

        //        //string json = JsonConvert.SerializeObject(country);

        //        // var settings = new JsonSerializerSettings
        //        //{
        //        //     PreserveReferencesHandling = PreserveReferencesHandling.Objects
        //        // };

        //        // string json = JsonConvert.SerializeObject(country, settings);

        //        string json = JsonConvert.SerializeObject(country, new JsonSerializerSettings
        //        {
        //            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        //        });

        //        //JsonSerializerOptions options = new JsonSerializerOptions();
        //        //options.ReferenceHandler = ReferenceHandler.Preserve;

        //        //var options = new JsonSerializerOptions
        //        //{
        //        //ReferenceHandler = ReferenceHandler.IgnoreCycles
        //        //};

        //        //string json = JsonSerializer.Serialize(country, options);

        //        return new JsonResult(Ok(json));
        //        //return new JsonResult(Ok(country));
        //    }
        //}

        ////[HttpPost]
        ////public JsonResult CreateCountry(String name, String nameOfContinent)
        ////{
        ////    if (name == "" || nameOfContinent == "")
        ////    {
        ////        return new JsonResult("Can't add empty value");
        ////    }
        ////    else
        ////    {
        ////       var continent = _context.continents.Where(x => x.Name == nameOfContinent).First();
        ////        Country country = new Country
        ////        {
        ////            Name = name,
        ////            ContinentId = continent.Id
        ////        };
        ////        _context.country.Add(country);
        ////        _context.SaveChanges();

        ////        var settings = new JsonSerializerSettings
        ////        {
        ////            PreserveReferencesHandling = PreserveReferencesHandling.Objects
        ////        };

        ////        string json = JsonConvert.SerializeObject(country, settings);

        ////        return new JsonResult(Ok(json));
        ////    }
        ////}

        //[HttpPost]
        //public JsonResult CreateEditCity(City city)
        //{
        //    if (city.Id == 0)
        //    {
        //        _context.cities.Add(city);
        //    }
        //    else
        //    {
        //        var cityInDb = _context.cities.Find(city.Id);
        //        if (cityInDb == null)
        //        {
        //            return new JsonResult(NotFound());
        //        }
        //        cityInDb = city;
        //    }
        //    _context.SaveChanges();
        //    return new JsonResult(Ok(city));
        //}
        //[HttpPost]
        //public JsonResult CreateEditHotel(Hotel hotel)
        //{
        //    if (hotel.Id == 0)
        //    {
        //        _context.hotels.Add(hotel);
        //    }
        //    else
        //    {
        //        var hotelInDb = _context.hotels.Find(hotel.Id);
        //        if (hotelInDb == null)
        //        {
        //            return new JsonResult(NotFound());
        //        }
        //        hotelInDb = hotel;
        //    }
        //    _context.SaveChanges();
        //    return new JsonResult(Ok(hotel));
        //}

        //[HttpPost]
        //public JsonResult CreateEditAirport(Airport airport)
        //{
        //    if (airport.Id == 0)
        //    {
        //        _context.airports.Add(airport);
        //    }
        //    else
        //    {
        //        var airportInDb = _context.airports.Find(airport.Id);
        //        if (airportInDb == null)
        //        {
        //            return new JsonResult(NotFound());
        //        }
        //        airportInDb = airport;
        //    }
        //    _context.SaveChanges();
        //    return new JsonResult(Ok(airport));
        //}

        //[HttpPost]
        //public JsonResult CreateEditTrip(Trip trip)
        //{
        //    if (trip.Id == 0)
        //    {
        //        _context.trips.Add(trip);
        //    }
        //    else
        //    {
        //        var tripInDb = _context.trips.Find(trip.Id);
        //        if (tripInDb == null)
        //        {
        //            return new JsonResult(NotFound());
        //        }
        //        tripInDb = trip;
        //    }
        //    _context.SaveChanges();
        //    return new JsonResult(Ok(trip));
        //}

        //[HttpPost]
        //public JsonResult CreateEditTripPurchase(TripPurchase tripPurchase)
        //{
        //    if (tripPurchase.Id == 0)
        //    {
        //        _context.tripPurchases.Add(tripPurchase);
        //    }
        //    else
        //    {
        //        var tripPurchaseInDb = _context.tripPurchases.Find(tripPurchase.Id);
        //        if (tripPurchaseInDb == null)
        //        {
        //            return new JsonResult(NotFound());
        //        }
        //        tripPurchaseInDb = tripPurchase;
        //    }
        //    _context.SaveChanges();
        //    return new JsonResult(Ok(tripPurchase));
        //}

        //[HttpPost]
        //public JsonResult CreateEditClient(Client client)
        //{
        //    if (client.Id == 0)
        //    {
        //        _context.clients.Add(client);
        //    }
        //    else
        //    {
        //        var clientInDb = _context.clients.Find(client.Id);
        //        if (clientInDb == null)
        //        {
        //            return new JsonResult(NotFound());
        //        }
        //        clientInDb = client;
        //    }
        //    _context.SaveChanges();
        //    return new JsonResult(Ok(client));
        //}

        //[HttpPost]
        //public JsonResult CreateEditAdmin(Admin admin)
        //{
        //    if (admin.Id == 0)
        //    {
        //        _context.admins.Add(admin);
        //    }
        //    else
        //    {
        //        var adminInDb = _context.admins.Find(admin.Id);
        //        if (adminInDb == null)
        //        {
        //            return new JsonResult(NotFound());
        //        }
        //        adminInDb = admin;
        //    }
        //    _context.SaveChanges();
        //    return new JsonResult(Ok(admin));
        //}

        [HttpPost]
        public async Task<ActionResult<Continent>> CreateContinent(String name)
        {
            if (name == "")
            {
                return new JsonResult("Can't add empty value");
            }
            else
            {
                Continent continent = new Continent(name);
                _context.continents.Add(continent);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetContinent), new { name = continent.Name }, continent);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Country>> CreateCountry(String name, String nameOfContinent)
        {
            if (name == "" || nameOfContinent == "")
            {
                return new JsonResult("Can't add empty value");
            }
            else
            {
                var continent = _context.continents.Where(x => x.Name == nameOfContinent).First();
                Country country = new Country(name, continent);
                _context.country.Add(country);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetCountry), new { name = country.Name }, country);

                //string json = JsonConvert.SerializeObject(country);

                // var settings = new JsonSerializerSettings
                //{
                //     PreserveReferencesHandling = PreserveReferencesHandling.Objects
                // };

                // string json = JsonConvert.SerializeObject(country, settings);

                //string json = JsonConvert.SerializeObject(country, new JsonSerializerSettings
                //{
                //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                //});

                //JsonSerializerOptions options = new JsonSerializerOptions();
                //options.ReferenceHandler = ReferenceHandler.Preserve;

                //var options = new JsonSerializerOptions
                //{
                //ReferenceHandler = ReferenceHandler.IgnoreCycles
                //};

                //string json = JsonSerializer.Serialize(country, options);
                //return new JsonResult(Ok(json));
                //return new JsonResult(Ok(country));
            }
        }

        [HttpPost]
        public async Task<ActionResult<City>> CreateCity(String name, String nameOfCountry)
        {
            if (name == "" || nameOfCountry == "")
            {
                return new JsonResult("Can't add empty value");
            }
            else
            {
                var country = _context.country.Where(x => x.Name == nameOfCountry).First();
                City city = new City(name, country);
                _context.cities.Add(city);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetCity), new { name = city.Name }, city);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Hotel>> CreateHotel(String name, Stars star, String nameOfCity)
        {
            if (name == "" || nameOfCity == "")
            {
                return new JsonResult("Can't add empty value");
            }
            else
            {
                var city = _context.cities.Where(x => x.Name == nameOfCity).First();
                Hotel hotel = new Hotel(name, star, city);
                _context.hotels.Add(hotel);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetHotel), new { name = hotel.Name }, hotel);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Airport>> CreateAirport(String name, String nameOfCity)
        {
            if (name == "" || nameOfCity == "")
            {
                return new JsonResult("Can't add empty value");
            }
            else
            {
                var city = _context.cities.Where(x => x.Name == nameOfCity).First();
                Airport airport = new Airport(name, city);
                _context.airports.Add(airport);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetAirport), new { name = airport.Name }, airport);
            }
        }

        [HttpGet]
        public DateTime GetTime()
        {
            return DateTime.Now;
        }

        [HttpPost]
        public async Task<ActionResult<Airport>> CreateTrip(String name, String fromAirportName, String toAirportName, String hotelName, DateTime deparutreDate,
            DateTime arrivalDate, decimal priceForAdult, decimal priceForChild, bool isLastMinute,
            bool isFirstMinute, int numberOfBooking)
        {
            if (fromAirportName == "" || toAirportName == "" || hotelName == "" || priceForAdult <= 0 || priceForChild <= 0 || numberOfBooking <= 0)
            {
                return new JsonResult("Can't add empty value or value under 0");
            }
            else
            {
                var fromAirport = _context.airports.Where(x => x.Name == fromAirportName).First();
                var toAirport = _context.airports.Where(x => x.Name == toAirportName).First();
                var hotel = _context.hotels.Where(x => x.Name == hotelName).First();

                Trip trip = new Trip(name, fromAirport, toAirport, hotel, deparutreDate,
            arrivalDate, priceForAdult, priceForChild, isLastMinute, isFirstMinute, numberOfBooking);

                _context.trips.Add(trip);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetTrip), new { id = trip.Id }, trip);
            }
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<List<Continent>>> GetContinent(String name)
        {
            var result = await _context.continents.Where(x => x.Name == name).ToListAsync();

            if (result == null)
                return NotFound();

            return result;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<List<Country>>> GetCountry(String name)
        {
            var result = await _context.country.Where(x => x.Name == name).ToListAsync();

            if (result == null)
                return NotFound();

            return result;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<List<City>>> GetCity(String name)
        {
            var result = await _context.cities.Where(x => x.Name == name).ToListAsync();

            if (result == null)
                return NotFound();

            return result;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<List<Hotel>>> GetHotel(String name)
        {
            var result = await _context.hotels.Where(x => x.Name == name).ToListAsync();

            if (result == null)
                return NotFound();

            return result;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<List<Airport>>> GetAirport(String name)
        {
            var result = await _context.airports.Where(x => x.Name == name).ToListAsync();

            if (result == null)
                return NotFound();

            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Trip>> GetTrip(int id)
        {
            var result = await _context.trips.FindAsync(id);

            if (result == null)
                return NotFound();

            return result;
        }

        [HttpDelete("{id}")]
        //public JsonResult DeleteContinent(int id)
        public async Task<IActionResult> DeleteContinent(int id)
        {
            var result = await _context.continents.FindAsync(id);

            if (result == null)
                return NotFound();

            _context.continents.Remove(result);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        //public JsonResult DeleteCountry(int id)
        public async Task<IActionResult> DeleteCountry(int id)
        {
            //var result = _context.country.Find(id);
            var result = await _context.country.FindAsync(id);

            if (result == null)
                return NotFound();

            _context.country.Remove(result);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<Continent>>> GetContinents()
        {
            if(_context.continents == null)
            {
                return NotFound();
            }

            return await _context.continents.ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<List<Country>>> GetCountries()
        {
            if (_context.country == null)
            {
                return NotFound();
            }

            return await _context.country.ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<List<City>>> GetCities()
        {
            if (_context.cities == null)
            {
                return NotFound();
            }

            return await _context.cities.ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<List<Hotel>>> GetHotels()
        {
            if (_context.hotels == null)
            {
                return NotFound();
            }

            return await _context.hotels.ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<List<Airport>>> GetAirports()
        {
            if (_context.airports == null)
            {
                return NotFound();
            }

            return await _context.airports.ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<List<Trip>>> GetTrips()
        {
            if (_context.trips == null)
            {
                return NotFound();
            }

            return await _context.trips.ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<List<TripPurchase>>> GetTripPurchases()
        {
            if (_context.tripPurchases == null)
            {
                return NotFound();
            }

            return await _context.tripPurchases.ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<List<Client>>> GetClients()
        {
            if (_context.clients == null)
            {
                return NotFound();
            }

            return await _context.clients.ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<List<Admin>>> GetAdmins()
        {
            if (_context.admins == null)
            {
                return NotFound();
            }

            return await _context.admins.ToListAsync();
        }
    }

}
