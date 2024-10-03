using inz.Data;
using inz.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace inz.Pages
{
    public class AdminCountryModel : PageModel
    {
        private readonly ILogger<AdminCountryModel> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public AdminCountryModel(ILogger<AdminCountryModel> logger, ApplicationDbContext context, UserManager<User> user)
        {
            _logger = logger;
            _context = context;
            _userManager = user;
        }

        public List<Country> countries { get; set; }

        [BindProperty]
        public int Id { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            countries = await _context.countries.Include(c => c.Continent).ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync()
        {
            var result = await _context.countries.FindAsync(Id);

            if (result == null)
                return NotFound();

            _context.countries.Remove(result);
            await _context.SaveChangesAsync();
            return Redirect("/AdminCountry");
        }
    }
}
