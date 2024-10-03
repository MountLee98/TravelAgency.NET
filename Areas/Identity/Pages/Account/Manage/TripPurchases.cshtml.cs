using inz.Data;
using inz.Model;
using inz.Pages;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace inz.Areas.Identity.Pages.Account.Manage
{
    public class TripPurchasesModel : PageModel
    {

        private readonly ILogger<TripPurchasesModel> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public TripPurchasesModel(ILogger<TripPurchasesModel> logger, ApplicationDbContext context, UserManager<User> user)
        {
            _logger = logger;
            _context = context;
            _userManager = user;
        }

        public List<TripPurchase> trips { get; set; }

        [BindProperty]
        public int Id { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            trips = await _context.tripPurchases.Where(t => t.User.Id == _userManager.GetUserId(User)).Include(t => t.Trip.FromAirport).Include(t => t.Trip.ToAirport).Include(t => t.Trip.Hotel).ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var result = await _context.tripPurchases.FindAsync(Id);

            if (result == null)
                return NotFound();

            _context.tripPurchases.Remove(result);
            await _context.SaveChangesAsync();
            return Redirect("/Identity/Account/Manage/TripPurchases");
        }
    }
}
