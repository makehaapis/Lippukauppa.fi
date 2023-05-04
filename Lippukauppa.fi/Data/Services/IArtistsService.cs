using Lippukauppa.fi.Models;

namespace Lippukauppa.fi.Data.Services
{
    public interface IArtistsService
    {
        Task<IEnumerable<Artist>> GetAllAsync();
        Task<Artist> GetByIdAsync(int id);
        Task AddAsync(Artist artist);
        Task<Artist> UpdateAsync(int id, Artist updatedArtist);
        Task DeleteAsync(int id);
    }
}
