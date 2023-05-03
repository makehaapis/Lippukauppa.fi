using Lippukauppa.fi.Models;
using Microsoft.EntityFrameworkCore;

namespace Lippukauppa.fi.Data.Services
{
    public class ArtistsService : IArtistsService
    {
        private readonly AppDbContext _context;
        public ArtistsService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Artist artist)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Artist>> GetAll()
        {
            var result = await _context.Artists.ToListAsync();
            return result;
        }

        public Artist GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Artist Update(int id, Artist newArtist)
        {
            throw new NotImplementedException();
        }
    }
}
