using inz.Data;
using inz.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace inz.Pages
{
    public class TripModel : PageModel
    {
        private readonly ILogger<TripModel> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public TripModel(ILogger<TripModel> logger, ApplicationDbContext context, UserManager<User> user)
        {
            _logger = logger;
            _context = context;
            _userManager = user;  
        }

        public int Id { get; set; }
        public Trip trip { get; set; }
        public List<Trip> TripsLastMinute { get; set; }
        [BindProperty]
        public int adultQuantity { get; set; }
        [BindProperty]
        public int childQuantity { get; set; }
        [BindProperty]
        public int Id2 { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            trip = await _context.trips.Where(i => i.Id == id || i.Id == Id2).Include(h => h.Hotel).Include(f => f.FromAirport).Include(t => t.ToAirport).FirstAsync();
            
            TripsLastMinute = await _context.trips.Where(t => t.IsLastMinute == true).Include(h => h.Hotel).Include(f => f.FromAirport).Take(4).ToListAsync();
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var trip2 = await _context.trips.Where(i => i.Id == Id2).FirstAsync();

            if(user == null || trip2 == null)
            {
                return Redirect("/Trip?id="+Id2);
            }

            decimal price = trip2.PriceForAdult * adultQuantity + trip2.PriceForChild * childQuantity;
            TripPurchase tripP = new TripPurchase(adultQuantity, childQuantity, price,  user, trip2);
            _context.tripPurchases.Add(tripP);
            await _context.SaveChangesAsync();

            return Redirect("/Identity/Account/Manage/TripPurchases");
        }
    }
}
