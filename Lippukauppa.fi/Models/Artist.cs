using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Lippukauppa.fi.Models
{
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }

        [Required(ErrorMessage = "Title is required!")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 30 characters")]
        public string? Title { get; set; }

        [Display(Name = "Profile Picture URL")]
        [Required(ErrorMessage = "Profile Picture is required ")]
        public string? ProfilePictureURL { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        //Relationships
       // public List<Artist_Event> Artists_Events { get; set; }
    }
}
