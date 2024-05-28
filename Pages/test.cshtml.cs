using Biuro_podrozy_praca_inzynierska.Data;
using Biuro_podrozy_praca_inzynierska.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Biuro_podrozy_praca_inzynierska.Pages
{
    public class TestModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public TestModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Trip> Trips { get; set; }
        public List<Country> Countries { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            Trips = await _context.trips.ToListAsync();
            Countries = await _context.country.Include(c => c.Continent).ThenInclude(c => c.Countries).Include(c => c.Cities).ToListAsync();

            return Page();
        }
    }
}
/*
 * 1. Mechanizm komponentów i ViewBag.
 * 2. Wyrzuæ id w joinach w modelach (sam dodaje pole id)
 * 3. Logger
 * 
 * 
 * 
 * */