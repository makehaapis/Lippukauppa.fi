using Lippukauppa.fi.Data;
using Microsoft.AspNetCore.Mvc;

namespace Lippukauppa.fi.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly AppDbContext _context;

        public ArtistsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Artists.ToList();
            return View(data);
        }
    }
}
