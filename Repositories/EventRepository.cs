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

        public IEnumerable<Event> GetAllEvents()
        {
            return _context.Events.Where(e => !e.IsDeleted).ToList();
        }
    }
}
