using Lippukauppa.fi.Data.Base;
using Lippukauppa.fi.Models;

namespace Lippukauppa.fi.Data.Services
{
    public class VenuesService : EntityBaseRepository<Venue>, IVenuesService
    {
        private readonly AppDbContext _context;
        public VenuesService(AppDbContext context) : base(context) { }
    }
}
