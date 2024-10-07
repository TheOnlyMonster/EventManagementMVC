namespace EventManagementWebApp.Models
{
    public class Member : User
    {
        public ICollection<Registration> Registrations { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
