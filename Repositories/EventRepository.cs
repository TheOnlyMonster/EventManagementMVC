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

        public Task CreateEventAsync(Event newEvent)
        {
            _context.Events.Add(newEvent);
            return _context.SaveChangesAsync();
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return _context.Events.Where(e => !e.IsDeleted).ToList();
        }
    }
}
