using EventManagementWebApp.Models;
using EventManagementWebApp.ViewModels;
using System.Security.Claims;

namespace EventManagementWebApp.Services
{
    public interface IEventService
    {
        IEnumerable<Event> GetEventsForDisplay();

        Task CreateEventAsync(EventViewModel model);
    }
}
