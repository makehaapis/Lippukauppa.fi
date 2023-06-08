using Lippukauppa.fi.Data;
using Lippukauppa.fi.Data.Services;
using Lippukauppa.fi.Data.Static;
using Lippukauppa.fi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lippukauppa.fi.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class VenuesController : Controller
    {
        private readonly IVenuesService _service;

        public VenuesController(IVenuesService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allVenues = await _service.GetAllAsync();
            return View(allVenues);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,VenuePictureURL, Description, Address, PostalCode, City")] Venue venue)
        {
            if (!ModelState.IsValid)
            {
                return View(venue);
            }
            await _service.AddAsync(venue);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var venueDetail = await _service.GetVenueByIdAsync(id);
            return View(venueDetail);
        }

        //Get: Venues/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var venueDetails = await _service.GetByIdAsync(id);
            if (venueDetails == null) return View("NotFound");
            return View(venueDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Name,VenuePictureURL,Description, Address, PostalCode, City")] Venue venue)
        {
            venue.Id = id;
            if (!ModelState.IsValid)
            {
                return View(venue);
            }
            await _service.UpdateAsync(id, venue);
            return RedirectToAction(nameof(Index));
        }

        //Get: Venues/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var venuesDetails = await _service.GetByIdAsync(id);
            if (venuesDetails == null) return View("NotFound");
            return View(venuesDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venueDetails = await _service.GetByIdAsync(id);

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
