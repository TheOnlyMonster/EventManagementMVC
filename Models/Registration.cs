namespace EventManagementWebApp.Models
{
    public class Registration
    {
        public int Id { get; set; }

        public int EventId { get; set; }

        public virtual Event Event { get; set; }

        public string MemberId { get; set; }

        public virtual Member Member { get; set; }

        public int Tickets { get; set; }
    }
}
