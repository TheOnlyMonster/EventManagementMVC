using EventManagementWebApp.Models;
using EventManagementWebApp.Repositories;
using EventManagementWebApp.ViewModels;
using System.Security.Claims;

namespace EventManagementWebApp.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public EventService(IEventRepository eventRepository, IHttpContextAccessor httpContextAccessor)
        {
            _eventRepository = eventRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public IEnumerable<Event> GetEventsForDisplay(string name, string location, DateTime? date)
        {
            var events = _eventRepository.GetAllEvents(name, location, date);
            return events;
        }

        public async Task CreateEventAsync(EventViewModel model)
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
                throw new UnauthorizedAccessException("User is not logged in.");

            var organizerId = int.Parse(userId);

            var newEvent = new Event
            {
                Name = model.Name,
                Description = model.Description,
                Date = model.Date,
                Location = model.Location,
                OrganizerId = organizerId
            };

            await _eventRepository.CreateEventAsync(newEvent);
        }

        public async Task DeleteEventAsync(int eventId)
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
                throw new UnauthorizedAccessException("User is not logged in.");

            var organizerId = int.Parse(userId);

            var eventToDelete = _eventRepository.GetEventById(eventId);

            if (eventToDelete == null)
                throw new ArgumentException("Event not found.");

            if (eventToDelete.OrganizerId != organizerId)
                throw new UnauthorizedAccessException("User is not the organizer of the event.");

            var result = await _eventRepository.DeleteEventAsync(eventId);

            if (result == 0)
                throw new InvalidOperationException("Failed to delete event.");

        }
    }
}
