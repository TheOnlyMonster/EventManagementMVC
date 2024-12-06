using EventManagementWebApp.Attributes;
using EventManagementWebApp.Models;
using EventManagementWebApp.Services;
using EventManagementWebApp.ViewModels;
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

        public IActionResult Index(string name, string location, DateTime? date)
        {
            IEnumerable<Event> events = _eventService.GetEventsForDisplay(name, location, date);

            return View(events);
        }

        [HttpGet]
        [Organizer]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Organizer]
        public async Task<IActionResult> Create(EventViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _eventService.CreateEventAsync(model); 
                return RedirectToAction("Index", "Event");
            }
            return View(model);
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Organizer]
        public async Task<IActionResult> Delete(int id)
        {
            await _eventService.DeleteEventAsync(id);
            return RedirectToAction("Index", "Event");
        }


    }
}
