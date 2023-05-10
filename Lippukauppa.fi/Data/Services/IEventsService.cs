using Lippukauppa.fi.Data.Base;
using Lippukauppa.fi.Data.ViewModels;
using Lippukauppa.fi.Models;
using System.ComponentModel;

namespace Lippukauppa.fi.Data.Services
{
    public interface IEventsService : IEntityBaseRepository<Event>
    {
        Task<Event> GetEventByIdAsync(int id);
        Task<NewEventDropdownsVM> GetNewEventDropdownsValues();
        Task AddNewEventAsync(NewEventVM data);
        Task UpdateEventAsync(int id, NewEventVM data);
    }
}
