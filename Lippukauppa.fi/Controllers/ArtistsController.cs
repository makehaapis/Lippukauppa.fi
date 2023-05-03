using Lippukauppa.fi.Data;
using Lippukauppa.fi.Data.Services;
using Lippukauppa.fi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lippukauppa.fi.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly IArtistsService _service;

        public ArtistsController(IArtistsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allArtists = await _service.GetAllAsync();
            return View(allArtists);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Title,ProfilePictureURL, Description")]Artist artist)
        {
            if(!ModelState.IsValid)
            {
                return View(artist);
            }
            await _service.AddAsync(artist);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var artistDetails = await _service.GetByIdAsync(id);
            if (artistDetails == null) return View("Empty");
            return View(artistDetails);
        }
    }
}
