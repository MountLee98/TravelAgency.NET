using inz.Data;
using inz.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace inz.Pages
{
    public class AdminCountryEditModel : PageModel
    {
        private readonly ILogger<AdminCountryEditModel> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public AdminCountryEditModel(ILogger<AdminCountryEditModel> logger, ApplicationDbContext context, UserManager<User> user)
        {
            _logger = logger;
            _context = context;
            _userManager = user;
        }

        public Country country { get; set; }
        [BindProperty]
        public int Id2 { get; set; }

        [BindProperty]
        public string name { get; set; }

        [BindProperty]
        public string continentName { get; set; }

        public List<Continent> continents { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            country = await _context.countries.Where(i => i.Id == id || i.Id == Id2).FirstAsync();
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
                Country updatedCountry = new Country(name, continent);
                country = await _context.countries.Where(i => i.Id == Id2).FirstAsync();

                if (country != null)
                {
                    country.Name = name;
                    country.Continent = continent;
                }
                await _context.SaveChangesAsync();

                return Redirect("/AdminCountry");
            }
        }
    }
}
