using Lippukauppa.fi.Data.Base;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace Lippukauppa.fi.Models
{
    public class Venue: IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string VenuePictureURL { get; set; }
        [Required(ErrorMessage = "Name is required!")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 30 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required!")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Address is required!")]
        public string Address { get; set; }
        [Required(ErrorMessage = "City is required!")]
        public string City { get; set; }
        [Required(ErrorMessage = "Postal code is required!")]
        public string PostalCode { get; set; }
    }
}
