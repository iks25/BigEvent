using System.ComponentModel.DataAnnotations;

namespace BigEvent.Models
{
    public class UserMessage
    {
        public int Id { get; set; }


        public Message Message { get; set; }

        [Required]
        public int MessageId { get; set; }
        public BasicUser BasicUser { get; set; }

        [Required]
        public int BasicUserId { get; set; }

        public bool HasBeenRead { get; set; }
    }
}