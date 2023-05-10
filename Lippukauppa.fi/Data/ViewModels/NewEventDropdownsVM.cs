using Lippukauppa.fi.Models;

namespace Lippukauppa.fi.Data.ViewModels
{
    public class NewEventDropdownsVM
    {
        public NewEventDropdownsVM()
        {
            Venues = new List<Venue>();
            Artists= new List<Artist>();
        }

        public List<Venue> Venues { get; set; }
        public List<Artist> Artists { get; set; }
    }
}
