using EventManagementWebApp.Data.Contracts;

namespace EventManagementWebApp.Models
{
    public class Review : ISoftDelete
    {
        public int Id { get; set; }

        public int EventId { get; set; }

        public virtual Event Event { get; set; }

        public int MemberId { get; set; }

        public virtual User Member { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; }

        public bool IsDeleted { get; set; }
    }
}
