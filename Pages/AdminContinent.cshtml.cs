using inz.Areas.Identity.Pages.Account.Manage;
using inz.Data;
using inz.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace inz.Pages
{
    public class AdminContinentModel : PageModel
    {
        private readonly ILogger<AdminContinentModel> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public AdminContinentModel(ILogger<AdminContinentModel> logger, ApplicationDbContext context, UserManager<User> user)
        {
            _logger = logger;
            _context = context;
            _userManager = user;
        }

        public List<Continent> continents { get; set; }

        [BindProperty]
        public int Id { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            continents = await _context.continents.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync()
        {
            var result = await _context.continents.FindAsync(Id);

            if (result == null)
                return NotFound();

            _context.continents.Remove(result);
            await _context.SaveChangesAsync();
            return Redirect("/AdminContinent");
        }
    }
}
