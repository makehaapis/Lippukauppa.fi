using Lippukauppa.fi.Data.Base;
using Lippukauppa.fi.Models;
using Microsoft.EntityFrameworkCore;

namespace Lippukauppa.fi.Data.Services
{
    public class ArtistsService : EntityBaseRepository<Artist>, IArtistsService
    {
        private readonly AppDbContext _context;
        public ArtistsService(AppDbContext context) : base(context) { }

    }
}
