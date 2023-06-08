using Lippukauppa.fi.Data.Base;
using Lippukauppa.fi.Models;

namespace Lippukauppa.fi.Data.Services
{
    public interface IVenuesService : IEntityBaseRepository<Venue>
    {
        Task<Venue> GetVenueByIdAsync(int id);
    }
}
