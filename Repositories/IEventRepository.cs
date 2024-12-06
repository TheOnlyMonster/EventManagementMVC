using EventManagementWebApp.Models;
using EventManagementWebApp.ViewModels;

namespace EventManagementWebApp.Repositories
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAllEvents();

        Task CreateEventAsync(Event newEvent); 
    }
}
