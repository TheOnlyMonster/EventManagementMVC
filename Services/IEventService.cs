using EventManagementWebApp.Models;
using EventManagementWebApp.ViewModels;
using System.Security.Claims;

namespace EventManagementWebApp.Services
{
    public interface IEventService
    {
        IEnumerable<Event> GetEventsForDisplay(string name, string location, DateTime? date);

        Task CreateEventAsync(EventViewModel model);
        Task DeleteEventAsync(int eventId);
    }
}
