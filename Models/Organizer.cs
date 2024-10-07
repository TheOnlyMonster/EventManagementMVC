namespace EventManagementWebApp.Models
{
    public class Organizer : User
    {
        public ICollection<Event> CreatedEvents { get; set; }
    }
}
