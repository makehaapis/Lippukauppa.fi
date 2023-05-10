using Lippukauppa.fi.Models;

namespace Lippukauppa.fi.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Venue
                if (!context.Venues.Any())
                {
                    context.Venues.AddRange(new List<Venue>()
                    {
                        new Venue()
                        {
                            Name = "Arena 1",
                            VenuePictureURL = "",
                            Description = "This is the description of the first arena",
                            Address = "Uudenmaankatu 1",
                            PostalCode = "05000",
                            City = "Helsinki"
                        },
                        new Venue()
                        {
                            Name = "Arena 2",
                            VenuePictureURL = "",
                            Description = "This is the description of the second arena",
                            Address = "Uudenmaankatu 2",
                            PostalCode = "05000",
                            City = "Helsinki"
                        },
                        new Venue()
                        {
                            Name = "Arena 3",
                            VenuePictureURL = "",
                            Description = "This is the description of the third arena",
                            Address = "Uudenmaankatu 3",
                            PostalCode = "05000",
                            City = "Helsinki"
                        },
                        new Venue()
                        {
                            Name = "Arena 4",
                            VenuePictureURL = "",
                            Description = "This is the description of the fourth arena",
                            Address = "Uudenmaankatu 4",
                            PostalCode = "05000",
                            City = "Helsinki"
                        },
                        new Venue()
                        {
                            Name = "Arena 5",
                            VenuePictureURL = "",
                            Description = "This is the description of the fifth arena",
                            Address = "Uudenmaankatu 5",
                            PostalCode = "05000",
                            City = "Helsinki"
                        },
                    });
                    context.SaveChanges();
                }
                //Artists
                if (!context.Artists.Any())
                {
                    context.Artists.AddRange(new List<Artist>()
                    {
                        new Artist()
                        {
                            Title = "Actor 1",
                            Description = "This is the Bio of the first actor",
                            ProfilePictureURL = ""
                        },
                        new Artist()
                        {
                            Title = "Actor 2",
                            Description = "This is the Bio of the second actor",
                            ProfilePictureURL = ""
                        },
                        new Artist()
                        {
                            Title = "Actor 3",
                            Description = "This is the Bio of the third actor",
                            ProfilePictureURL = ""
                        },
                        new Artist()
                        {
                            Title = "Actor 4",
                            Description = "This is the Bio of the fourth actor",
                            ProfilePictureURL = ""
                        },
                        new Artist()
                        {
                            Title = "Actor 5",
                            Description = "This is the Bio of the fifth actor",
                            ProfilePictureURL = ""
                        },
                    });
                    context.SaveChanges();
                }
                
                //Events
                if (!context.Events.Any())
                {
                    context.Events.AddRange(new List<Event>()
                    {
                        new Event()
                        {
                            Name = "Life",
                            Description = "This is the Life movie description",
                            TicketPrice = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            SellStartDate = DateTime.Now.AddDays(-10),
                            VenueId = 1,
                            TicketQuantity = 1000,
                        },
                        new Event()
                        {
                            Name = "Life",
                            Description = "This is the Life movie description",
                            TicketPrice = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            SellStartDate = DateTime.Now.AddDays(-10),
                            VenueId = 3,
                            TicketQuantity = 1000,
                        },
                        new Event()
                        {
                            Name = "Life",
                            Description = "This is the Life movie description",
                            TicketPrice = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            SellStartDate = DateTime.Now.AddDays(-10),
                            VenueId = 2,
                            TicketQuantity = 1000,
                        },
                        new Event()
                        {
                            Name = "Life",
                            Description = "This is the Life movie description",
                            TicketPrice = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            SellStartDate = DateTime.Now.AddDays(-10),
                            VenueId = 1,
                            TicketQuantity = 1000,
                        },
                        new Event()
                        {
                            Name = "Life",
                            Description = "This is the Life movie description",
                            TicketPrice = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            SellStartDate = DateTime.Now.AddDays(-10),
                            VenueId = 1,
                            TicketQuantity = 1000,
                        },
                        new Event()
                        {
                            Name = "Life",
                            Description = "This is the Life movie description",
                            TicketPrice = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            SellStartDate = DateTime.Now.AddDays(-10),
                            VenueId = 2,
                            TicketQuantity = 1000,
                        },
                    });
                    context.SaveChanges();
                }
                //Actors & Movies
                if (!context.Artists_Events.Any())
                {
                    context.Artists_Events.AddRange(new List<Artist_Event>()
                    {
                        new Artist_Event()
                        {
                            ArtistId = 1,
                            EventId = 1
                        },
                        new Artist_Event()
                        {
                            ArtistId = 3,
                            EventId = 1
                        },
                         new Artist_Event()
                        {
                            ArtistId = 1,
                            EventId = 2
                        },
                         new Artist_Event () 
                        { 
                             ArtistId = 4, EventId = 2 
                         },
                        new Artist_Event () { ArtistId = 1, EventId = 3 },
                        new Artist_Event () { ArtistId = 2, EventId = 3 },
                        new Artist_Event () { ArtistId = 5, EventId = 3 },


                        new Artist_Event () { ArtistId = 2, EventId = 4 },
                        new Artist_Event () { ArtistId = 3, EventId = 4 },
                        new Artist_Event () { ArtistId = 4, EventId = 4 },


                        new Artist_Event () { ArtistId = 2, EventId = 5 },
                        new Artist_Event () { ArtistId = 3, EventId = 5 },
                        new Artist_Event () { ArtistId = 4, EventId = 5 },
                        new Artist_Event () { ArtistId = 5, EventId = 5 },


                        new Artist_Event () { ArtistId = 3, EventId = 6 },
                        new Artist_Event () { ArtistId = 4, EventId = 6 },
                        new Artist_Event () { ArtistId = 5, EventId = 6 },
                    });
                    context.SaveChanges();
                }
            }

        }
    }
}