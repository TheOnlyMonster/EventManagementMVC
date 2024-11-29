using EventManagementWebApp.Models;
using EventManagementWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementWebApp.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        public IActionResult Index()
        {
            IEnumerable<Event> events = _eventService.GetEventsForDisplay();
            return View(events);
        }
    }
}
