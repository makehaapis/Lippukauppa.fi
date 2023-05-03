using Lippukauppa.fi.Models;

namespace Lippukauppa.fi.Data.Services
{
    public interface IArtistsService
    {
        Task<IEnumerable<Artist>> GetAll();
        Artist GetById(int id);
        void Add(Artist artist);
        Artist Update(int id, Artist newArtist);
        void Delete(int id);
    }
}
