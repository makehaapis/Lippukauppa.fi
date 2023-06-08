using Lippukauppa.fi.Data.Base;
using Lippukauppa.fi.Data.ViewModels;
using Lippukauppa.fi.Models;
using Microsoft.EntityFrameworkCore;

namespace Lippukauppa.fi.Data.Services
{
    public class EventsService : EntityBaseRepository<Event>, IEventsService
    {
        private readonly AppDbContext _context;
        public EventsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewEventAsync(NewEventVM data)
        {
            var newEvent = new Event()
            {
                Name = data.Name,
                Description= data.Description,
                ImageURL = data.ImageURL,
                WideImageURL = data.WideImageURL,
                TicketPrice = data.TicketPrice,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                SellStartDate = data.SellStartDate,
                TicketQuantity = data.TicketQuantity,
                VenueId = data.VenueId,
            };
            await _context.Events.AddAsync(newEvent);
            await _context.SaveChangesAsync();

            foreach (var artistid in data.ArtistIDs) 
            {
                var newArtistEvent = new Artist_Event()
                {
                    EventId = newEvent.Id,
                    ArtistId = artistid,
                };
                await _context.Artists_Events.AddAsync(newArtistEvent);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Event> GetEventByIdAsync(int id)
        {
            var eventDetails = _context.Events.Include(v => v.venue).Include(ae => ae.Artists_Events).ThenInclude(a => a.Artist).FirstOrDefaultAsync(n => n.Id == id);
            return await eventDetails;
        }

        public async Task<NewEventDropdownsVM> GetNewEventDropdownsValues()
        {
            var response = new NewEventDropdownsVM()
            {
                Artists = await _context.Artists.OrderBy(n => n.Title).ToListAsync(),
                Venues = await _context.Venues.OrderBy(n => n.Name).ToListAsync()
            };
            return response;
        }

        public async Task UpdateEventAsync(int id, NewEventVM data)
        {
            var dbEvent = await _context.Events.FirstOrDefaultAsync(e => e.Id == data.Id);

            if (dbEvent != null)
            {
                dbEvent.Name = data.Name;
                dbEvent.Description = data.Description;
                dbEvent.ImageURL = data.ImageURL;
                dbEvent.WideImageURL = data.WideImageURL;
                dbEvent.TicketPrice = data.TicketPrice;
                dbEvent.StartDate = data.StartDate;
                dbEvent.EndDate = data.EndDate;
                dbEvent.SellStartDate = data.SellStartDate;
                dbEvent.TicketQuantity = data.TicketQuantity;
                dbEvent.VenueId = data.VenueId;
                await _context.SaveChangesAsync();
            };

            var existingArtistsDb = _context.Artists_Events.Where(n => n.EventId == data.Id).ToList();
            _context.Artists_Events.RemoveRange(existingArtistsDb);
            _context.SaveChanges();
            foreach (var artistid in data.ArtistIDs)
            {
                var newArtistEvent = new Artist_Event()
                {
                    EventId = data.Id,
                    ArtistId = artistid,
                };
                await _context.Artists_Events.AddAsync(newArtistEvent);
            }
            await _context.SaveChangesAsync();
        }
    }
}
