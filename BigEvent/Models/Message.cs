using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace BigEvent.Models
{
    public class Message
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public Organizer Organizer { get; set; }
        public int OrganizerId { get; set; }
        public Event Event { get; set; }
        public int EventId { get; set; }
        public MessageType Type { get; set; }
        public Message()
        {

        }
    }

    public enum MessageType
    {
        editMessage, deleteMessage
    }
}