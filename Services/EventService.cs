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

        public IEnumerable<Event> GetEventsForDisplay()
        {
            var events = _eventRepository.GetAllEvents();
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

    }
}
