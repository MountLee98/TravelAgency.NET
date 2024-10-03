using inz.Data;
using inz.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace inz.Pages
{
    public class LastMinuteModel : PageModel
    {
        private readonly ILogger<LastMinuteModel> _logger;
        private readonly ApplicationDbContext _context;

        public List<Trip> TripsLastMinute { get; set; }

        public LastMinuteModel(ILogger<LastMinuteModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            TripsLastMinute = await _context.trips.Where(t => t.IsLastMinute == true).Include(h => h.Hotel).Include(f => f.FromAirport).ToListAsync();
            
            return Page();
        }
    }
}
