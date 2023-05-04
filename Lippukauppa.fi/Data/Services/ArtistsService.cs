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

        public async Task AddAsync(Artist artist)
        {
            await _context.Artists.AddAsync(artist);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Artist>> GetAllAsync()
        {
            var result = await _context.Artists.ToListAsync();
            return result;
        }

        public async Task<Artist> GetByIdAsync(int id)
        {
            var result = await _context.Artists.FirstOrDefaultAsync(n => n.ArtistId == id);
            return result;
        }

        public async Task<Artist> UpdateAsync(int id, Artist updatedArtist)
        {
            _context.Update(updatedArtist);
            await _context.SaveChangesAsync();
            return updatedArtist;
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Artists.FirstOrDefaultAsync(n => n.ArtistId == id);
            _context.Artists.Remove(result);
            await _context.SaveChangesAsync();
        }
    }
}
