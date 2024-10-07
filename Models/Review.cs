namespace EventManagementWebApp.Models
{
    public class Review
    {
        public int Id { get; set; }

        public int EventId { get; set; }

        public virtual Event Event { get; set; }

        public string MemberId { get; set; }

        public virtual Member Member { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; }
    }
}
