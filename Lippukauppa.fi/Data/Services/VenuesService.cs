using Lippukauppa.fi.Data.Base;
using Lippukauppa.fi.Models;
using Microsoft.EntityFrameworkCore;

namespace Lippukauppa.fi.Data.Services
{
    public class VenuesService : EntityBaseRepository<Venue>, IVenuesService
    {
        private readonly AppDbContext _context;
        public VenuesService(AppDbContext context) : base(context) 
        {
            _context= context;
        }

        public async Task<Venue> GetVenueByIdAsync(int id)
        {
            var venueDetails = _context.Venues.Include(e => e.Events).FirstOrDefaultAsync(n => n.Id == id);
            return await venueDetails;
        }
    }
}
