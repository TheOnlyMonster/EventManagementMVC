using EventManagementWebApp.Models;

namespace EventManagementWebApp.Repositories
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAllEvents();
    }
}
