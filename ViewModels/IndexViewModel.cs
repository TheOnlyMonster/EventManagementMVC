using EventManagementWebApp.Models;

namespace EventManagementWebApp.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Event> SliderEvents { get; set; }
        public IEnumerable<Event> EventsTable { get; set; }
    }

}
