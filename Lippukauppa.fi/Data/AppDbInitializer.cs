using Lippukauppa.fi.Models;

namespace Lippukauppa.fi.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var servicesScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = servicesScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                //Location
                if (!context.Venues.Any())
                {
                    context.Venues.AddRange(new List<Venue>()
                    {
                        new Venue()
                        {
                            VenuePictureURL = "https://image.newyork.fi/wp-content/uploads/2015/03/Madison-Square-Garden-in-New-York.jpg",
                            Name = "Madison Square Garden",
                            Description = "Experience the unforgettable at Madison Square Garden, where history happens at The World's Most Famous Arena.",
                            Address = "Hämeenkatu 1",
                            PostalCode = "01000",
                            City = "Helsinki"
                        },

                        new Venue()
                        {
                            VenuePictureURL = "https://www.ilves.com/wp-content/uploads/2021/11/nokia-areena.jpg",
                            Name = "Nokia areena",
                            Description = "Nokia Arena on 15 000 katsojapaikkaa tarjoava elämysareena Tampereen sydämessä. Areenan yhteydessä toimii myös huippuluokan hotelli, kansainvälinen kasino, monipuoliset kokous- ja tapahtumatilat sekä lukuisia ravintoloita. Tarjoamme uniikin tapahtumakokemuksen, jollaista ei saa mistään muualta.",
                            Address = "Hämeenkatu 1",
                            PostalCode = "01000",
                            City = "Helsinki"
                        },

                        new Venue()
                        {
                            VenuePictureURL = "https://files.venuu.se/attachments/000/121/960/a9de00fadeca6af04e4bdb7cfdb9695b9dab2b60.jpg",
                            Name = "Kantolan Tapahtumapuisto",
                            Description = "Kantolan tapahtumapuisto sijaitsee Hämeenlinnassa, noin tunnin matkan päässä Helsingistä ja Tampereelta. Järven rannalla sijaitseva 9,5 hehtaarin kokoinen vehreä puistoalue toimii monipuolisten tapahtumien näyttämönä.",
                            Address = "Hämeenkatu 1",
                            PostalCode = "01000",
                            City = "Helsinki"
                        },
                    });
                    context.SaveChanges();
                }

                //Artist
                if (!context.Artists.Any())
                {
                    context.Artists.AddRange(new List<Artist>() {
                        new Artist
                        {
                            Title = "Antti Tuisku",
                            ProfilePictureURL = "http://www.tiketti.fi/kuvat/EV78412_7_768x470.jpg",
                            Description = "Suomen kirkkain poptähti Antti Tuisku julkaisi vuoden 2021 alussa uuden Treenaa-singlen, jota seurasivat toinen sinkku Kipee ja seitsemän biisin MASTER WORKOUT -EP. Siinä missä helmikuussa 2020 ilmestyneellä Valittu kansa -albumilla Antti pohti elämän hengellistä puolta, käsittelevät uudet kappaleet fyysistä laitaa. Yhteistä julkaisuilla on kuitenkin yhteiskunnallisesti kantaaottava ja syvällinen teema, jossa on mukana Antille ominaista itseironiaa.",
                        },
                        new Artist
                        {
                            Title = "Arch Enemy",
                            ProfilePictureURL = "https://www.soundi.fi/wp-content/uploads/2017/10/arch-enemy-2017-800x533.jpg",
                            Description = "Arch Enemy on ruotsalainen melodinen death metal -yhtye, jonka Michael Amott perusti vuonna 1995. Yhtye on julkaissut kymmenen studioalbumia, kolme livealbumia sekä neljä EP:tä",
                        },
                    });
                    context.SaveChanges();
                }

                //Event
                if (!context.Events.Any())
                {
                    context.Events.AddRange(new List<Event>()
                    {
                        new Event
                        {
                            Name = "Puisto Blues",
                            Description = "Legendaarinen festivaali",
                            TicketPrice = 20.90,
                            StartDate = DateTime.Parse("29/01/2023"),
                            EndDate = DateTime.Parse("29/01/2023"),
                            SellStartDate = DateTime.Parse("29/01/2023"),

                            ImageUrl =  ""
                        },
                        new Event
                        {
                            Name = "Puisto Blues",
                            Description = "Legendaarinen festivaali",
                            TicketPrice = 59.90,
                            StartDate = DateTime.Parse("29/01/2023"),
                            EndDate = DateTime.Parse("29/01/2023"),
                            SellStartDate = DateTime.Parse("29/01/2023"),
                            ImageUrl =  ""
                        },
                        new Event
                        {
                            Name = "Puisto Blues",
                            Description = "Legendaarinen festivaali",
                            TicketPrice = 39.50,
                            StartDate = DateTime.Parse("29/01/2023"),
                            EndDate = DateTime.Parse("29/01/2023"),
                            SellStartDate = DateTime.Parse("29/01/2023"),
                            ImageUrl =  "https://www.lippu.fi/obj/media/FI-eventim/teaser/evo/1x1/2022/WT_amore156x198.jpg",
                        },
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}