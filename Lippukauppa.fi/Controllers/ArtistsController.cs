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
            var allArtists = await _service.GetAll();
            return View(allArtists);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Title,ProfilePictureURL, Description")]Artist artist)
        {
            if(ModelState.IsValid)
            {
                return View(artist);
            }
            _service.Add(artist);
            return RedirectToAction(nameof(Index));
        }
    }
}
