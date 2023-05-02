using Lippukauppa.fi.Models;
using Microsoft.EntityFrameworkCore;

namespace Lippukauppa.fi.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist_Event>().HasKey(ae => new
            {
                ae.ArtistId,
                ae.EventId
            });

            modelBuilder.Entity<Artist_Event>().HasOne(e => e.Event).WithMany(ae => ae.Artists_Events).HasForeignKey(e =>
            e.EventId);
            modelBuilder.Entity<Artist_Event>().HasOne(a => a.Artist).WithMany(ae => ae.Artists_Events).HasForeignKey(a =>
            a.ArtistId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Artist_Event> Artist_Events { get; set; }
        public DbSet<Venue> VEnues { get; set; }
    }
}
