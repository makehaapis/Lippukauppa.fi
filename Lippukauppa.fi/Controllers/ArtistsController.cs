﻿using Lippukauppa.fi.Data;
using Lippukauppa.fi.Data.Services;
using Lippukauppa.fi.Data.Static;
using Lippukauppa.fi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Lippukauppa.fi.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ArtistsController : Controller
    {
        private readonly IArtistsService _service;

        public ArtistsController(IArtistsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allArtists = await _service.GetAllAsync();
            return View(allArtists);
        }

        [AllowAnonymous]
        //GET: Artists/Details/id
        public async Task<IActionResult> Details(int id)
        {
            var artistDetail = await _service.GetArtistByIdAsync(id);
            return View(artistDetail);
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

        //Get: Artists/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var artistDetails = await _service.GetByIdAsync(id);
            if (artistDetails == null) return View("NotFound");
            return View(artistDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Title,ProfilePictureURL,Description")] Artist artist)
        {
            artist.Id = id;
            if (!ModelState.IsValid)
            {
                return View(artist);
            }
            await _service.UpdateAsync(id, artist);
            return RedirectToAction(nameof(Index));
        }

        //Get: Artists/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var artistDetails = await _service.GetByIdAsync(id);
            if (artistDetails == null) return View("NotFound");
            return View(artistDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artistDetails = await _service.GetByIdAsync(id);

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}