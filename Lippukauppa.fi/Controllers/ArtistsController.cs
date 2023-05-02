﻿using Lippukauppa.fi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lippukauppa.fi.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly AppDbContext _context;

        public ArtistsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allArtists = await _context.Artists.ToListAsync();
            return View(allArtists);
        }
    }
}