using Lippukauppa.fi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lippukauppa.fi.Controllers
{
    public class VenuesController : Controller
    {
        private readonly AppDbContext _context;

        public VenuesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allVenues = await _context.Venues.ToListAsync();
            return View(allVenues);
        }
    }
}
