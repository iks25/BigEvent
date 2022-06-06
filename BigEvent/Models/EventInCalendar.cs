using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigEvent.Models
{
    public class EventInCalendar
    {
        public int Id { get; set; }
        public BasicUser User { get; set; }

        [Required]
        public int UserId { get; set; }

        public Event Event { get; set; }

        [Required]
        public int EventId { get; set; }

        [Required]
        public DataType EventDate { get; set; }
    }
}
