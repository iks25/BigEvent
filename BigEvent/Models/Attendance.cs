using System.ComponentModel.DataAnnotations;

namespace BigEvent.Models
{
    public class Attendance
    {
        public int Id { get; set; }

        public Event Event { get; set; }

        [Required]
        public int EventId { get; set; }

        public BasicUser BasicUser { get; set; }

        [Required]
        public int BasicUserId { get; set; }
    }
}
