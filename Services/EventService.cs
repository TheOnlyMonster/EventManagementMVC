using EventManagementWebApp.Models;
using EventManagementWebApp.Repositories;

namespace EventManagementWebApp.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public IEnumerable<Event> GetEventsForDisplay()
        {
            var events = _eventRepository.GetAllEvents();
            return events;
        }
    }
}
