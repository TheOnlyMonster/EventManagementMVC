using EventManagementWebApp.Models;

namespace EventManagementWebApp.Services
{
    public interface IEventService
    {
        IEnumerable<Event> GetEventsForDisplay();
    }
}
