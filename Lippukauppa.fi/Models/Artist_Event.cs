namespace Lippukauppa.fi.Models
{
    public class Artist_Event
    {
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
