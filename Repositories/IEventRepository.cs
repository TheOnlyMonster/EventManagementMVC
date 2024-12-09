using EventManagementWebApp.Models;
using EventManagementWebApp.ViewModels;

namespace EventManagementWebApp.Repositories
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAllEvents(string name, string location, DateTime? date);

        Task<int> CreateEventAsync(Event newEvent);
        Event GetEventById(int eventId);
        Task<int> DeleteEventAsync(int eventId);

        IEnumerable<Event> GetEvents(int numberOfEvents);



    }
}
