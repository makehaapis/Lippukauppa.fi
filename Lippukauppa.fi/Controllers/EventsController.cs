﻿using Lippukauppa.fi.Data;
using Lippukauppa.fi.Data.Services;
using Lippukauppa.fi.Data.Static;
using Lippukauppa.fi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.Tracing;

namespace Lippukauppa.fi.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class EventsController : Controller
    {
        private readonly IEventsService _service;

        public EventsController(IEventsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allEvents = await _service.GetAllAsync(n => n.venue);
            var filteredEvents = allEvents.Where(n => n.EndDate > DateTime.UtcNow); 
            return View(filteredEvents);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allEvents = await _service.GetAllAsync(n => n.venue);

            if (!String.IsNullOrEmpty(searchString)) 
            {
                var filteredEvents = allEvents.Where(e => e.Name.ToLower().Contains(searchString.ToLower())).ToList();
                return View("Index", filteredEvents);
            }
            return View("Index",allEvents);
        }

        //GET: Events/Details/id
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var eventDetail = await _service.GetEventByIdAsync(id);
            return View(eventDetail);
        }
        //Get: Events/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var eventDetails = await _service.GetByIdAsync(id);
            if (eventDetails == null) return View("NotFound");
            return View(eventDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventDetails = await _service.GetByIdAsync(id);

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        //Get: Events/Create/
        public async Task<IActionResult> Create()
        {
            var eventDropdownsData = await _service.GetNewEventDropdownsValues();
            ViewBag.Venues = new SelectList(eventDropdownsData.Venues, "Id", "Name");
            ViewBag.Artists = new SelectList(eventDropdownsData.Artists, "Id", "Title");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewEventVM eventti)
        {
            if (!ModelState.IsValid)
            {
                var eventDropdownsData = await _service.GetNewEventDropdownsValues();
                ViewBag.Venues = new SelectList(eventDropdownsData.Venues, "Id", "Name");
                ViewBag.Artists = new SelectList(eventDropdownsData.Artists, "Id", "Title");
                return View(eventti);
            }
            await _service.AddNewEventAsync(eventti);
            return RedirectToAction(nameof(Index));
        }

        //Get: Events/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var eventDetails = await _service.GetEventByIdAsync(id);
            if (eventDetails == null) return View("NotFound");

            var response = new NewEventVM()
            {
                Id = eventDetails.Id,
                Name = eventDetails.Name,
                Description = eventDetails.Description,
                TicketPrice = eventDetails.TicketPrice,
                TicketQuantity = eventDetails.TicketQuantity,
                SellStartDate = eventDetails.SellStartDate,
                StartDate = eventDetails.StartDate,
                EndDate = eventDetails.EndDate,
                ImageURL = eventDetails.ImageURL,
                WideImageURL = eventDetails.WideImageURL,
                VenueId = eventDetails.VenueId,
                ArtistIDs = eventDetails.Artists_Events.Select(n => n.ArtistId).ToList(),
            };

            var eventDropdownsData = await _service.GetNewEventDropdownsValues();
            ViewBag.Venues = new SelectList(eventDropdownsData.Venues, "Id", "Name");
            ViewBag.Artists = new SelectList(eventDropdownsData.Artists, "Id", "Title");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewEventVM eventti)
        {
            if (id != eventti.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var eventDropdownsData = await _service.GetNewEventDropdownsValues();
                ViewBag.Venues = new SelectList(eventDropdownsData.Venues, "Id", "Name");
                ViewBag.Artists = new SelectList(eventDropdownsData.Artists, "Id", "Title");
                return View(eventti);
            }
            await _service.UpdateEventAsync(id, eventti);
            return RedirectToAction(nameof(Index));
        }
    }
}