using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lippukauppa.fi.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public string? ImageUrl { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double TicketPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DateTime SellStartDate { get; set; }
        public int TicketQuantity { get; set; }

        //Relationships
        public List<Artist_Event> Artists_Events { get; set; }
        //Location
        public int LocationId { get; set; }
        [ForeignKey("LocationId")]

        public Venue Venue { get; set; }

    }
}
