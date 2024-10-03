using inz.Data;
using inz.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace inz.Pages
{
    public class AdminContinentCreateModel : PageModel
    {
        private readonly ILogger<AdminContinentCreateModel> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public AdminContinentCreateModel(ILogger<AdminContinentCreateModel> logger, ApplicationDbContext context, UserManager<User> user)
        {
            _logger = logger;
            _context = context;
            _userManager = user;
        }

        [BindProperty]
        public string name { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (name == "")
            {
                return Redirect("/AdminContinent");
            }
            else
            {
                Continent continent = new Continent(name);
                _context.continents.Add(continent);
                await _context.SaveChangesAsync();

                return Redirect("/AdminContinent");
            }
        }
    }
}
