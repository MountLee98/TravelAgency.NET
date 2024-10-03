using inz.Data;
using inz.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace inz.Pages
{
    public class AdminCountryCreateModel : PageModel
    {
        private readonly ILogger<AdminCountryCreateModel> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public AdminCountryCreateModel(ILogger<AdminCountryCreateModel> logger, ApplicationDbContext context, UserManager<User> user)
        {
            _logger = logger;
            _context = context;
            _userManager = user;
        }

        [BindProperty]
        public string name { get; set; }
        [BindProperty]
        public string continentName { get; set; }

        public List<Continent> continents { get; set; }

        public async Task<IActionResult> OnGet()
        {
            continents = await _context.continents.ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (name == "")
            {
                return Redirect("/AdminCountry");
            }
            else
            {
                Continent continent = await _context.continents.Where(c => c.Name == continentName).FirstAsync();
                if(continent == null)
                {
                    return Redirect("/AdminCountry");
                }
                Country country = new Country(name, continent);
                _context.countries.Add(country);
                await _context.SaveChangesAsync();

                return Redirect("/AdminCountry");
            }
        }
    }
}
