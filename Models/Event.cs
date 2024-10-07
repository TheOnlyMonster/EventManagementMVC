namespace EventManagementWebApp.Models
{
    public class Event
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string Location { get; set; }

        public int OrganizerId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Registration> Registrations { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
