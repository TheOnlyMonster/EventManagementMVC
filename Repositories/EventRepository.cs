using EventManagementWebApp.Data;
using EventManagementWebApp.Models;

namespace EventManagementWebApp.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _context;

        public EventRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<int> CreateEventAsync(Event newEvent)
        {
            _context.Events.Add(newEvent);
            return _context.SaveChangesAsync();
        }


        public Task<int> DeleteEventAsync(int eventId)
        {
            var eventToDelete = _context.Events.FirstOrDefault(e => e.Id == eventId);

            if (eventToDelete != null)
            {
                eventToDelete.IsDeleted = true;
                return _context.SaveChangesAsync();
            }

            return Task.FromResult(0);
        }

        public IEnumerable<Event> GetAllEvents(string name = null, string location = null, DateTime? date = null)
        {
            var query = _context.Events.Where(e => !e.IsDeleted).AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.Name.Contains(name));
            }

            if (!string.IsNullOrEmpty(location))
            {
                query = query.Where(e => e.Location.Contains(location));
            }

            if (date.HasValue)
            {
                query = query.Where(e => e.Date.Date == date.Value.Date);
            }

            return query.ToList();
        }

        public Event GetEventById(int eventId)
        {
            return _context.Events.FirstOrDefault(e => e.Id == eventId);
        }

        public IEnumerable<Event> GetEvents(int numberOfEvents)
        {
            return _context.Events.Where(e => !e.IsDeleted).Take(numberOfEvents).ToList();
        }

        
    }
}
