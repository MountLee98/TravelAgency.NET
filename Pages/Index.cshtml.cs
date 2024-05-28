using Biuro_podrozy_praca_inzynierska.Data;
using Biuro_podrozy_praca_inzynierska.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Biuro_podrozy_praca_inzynierska.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Trip> TripsLastMinute { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            TripsLastMinute = await _context.trips.Where(t => t.IsLastMinute == true).Include(h => h.Hotel).Include(f => f.FromAirport).ToListAsync();
            return Page();
        }
    }
}
