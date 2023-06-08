using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Lippukauppa.fi.Data.Base;

namespace Lippukauppa.fi.Models
{
    public class Event: IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string ImageURL { get; set; }
        public string WideImageURL { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double TicketPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DateTime SellStartDate { get; set; }
        public int TicketQuantity { get; set; }

        //Relationships
        public List<Artist_Event> Artists_Events { get; set; }

        //Venue
        public int VenueId { get; set; }
        public Venue venue { get; set; }
    }
}
