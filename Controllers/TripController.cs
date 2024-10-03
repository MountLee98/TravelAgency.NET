using inz.Data;
using inz.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace inz.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TripController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TripController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult ShowImage(int id)
        {
            var image = _context.trips.Find(id);
            if (image != null)
            {
                return File(image.ImageData, "image/jpeg"); // You can set the appropriate content type.
            }
            else
            {
                return Content("Image not found");
            }
        }



    }
}
