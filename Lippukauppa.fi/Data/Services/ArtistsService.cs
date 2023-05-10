using Lippukauppa.fi.Data.Base;
using Lippukauppa.fi.Models;
using Microsoft.EntityFrameworkCore;

namespace Lippukauppa.fi.Data.Services
{
    public class ArtistsService : EntityBaseRepository<Artist>, IArtistsService
    {
        private readonly AppDbContext _context;
        public ArtistsService(AppDbContext context) : base(context) 
        {
            _context = context;
        }
        public async Task<Artist> GetArtistByIdAsync(int id)
        {
            var artistDetails = _context.Artists.Include(ae => ae.Artists_Events).ThenInclude(e => e.Event).FirstOrDefaultAsync(n => n.Id == id);
            return await artistDetails;
        }
    }
}
