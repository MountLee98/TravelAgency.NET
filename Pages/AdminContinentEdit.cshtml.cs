using inz.Data;
using inz.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace inz.Pages
{
    public class AdminContinentEditModel : PageModel
    {
        private readonly ILogger<AdminContinentEditModel> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public AdminContinentEditModel(ILogger<AdminContinentEditModel> logger, ApplicationDbContext context, UserManager<User> user)
        {
            _logger = logger;
            _context = context;
            _userManager = user;
        }

        public Continent continent { get; set; }
        [BindProperty]
        public int Id2 { get; set; }

        [BindProperty]
        public string name { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            continent = await _context.continents.Where(i => i.Id == id || i.Id == Id2).FirstAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (name == "")
            {
                return Redirect("/AdminContinent");
            }
            else
            {
                Continent updatedContinent = new Continent(name);
                continent = await _context.continents.Where(i => i.Id == Id2).FirstAsync();

                if (continent != null)
                {
                    continent.Name = name;
                }
                await _context.SaveChangesAsync();

                return Redirect("/AdminContinent");
            }
        }
    }
}
