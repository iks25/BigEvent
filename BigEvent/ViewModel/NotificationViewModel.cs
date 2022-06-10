using System;
using BigEvent.Models;

namespace BigEvent.ViewModel
{
    public class NotificationViewModel
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string OrganizerName { get; set; }
        public int? OrganizerId { get; set; }
        public string EventName { get; set; }
        public int? EventId { get; set; }
        public MessageType Type { get; set; }
        public Boolean HasBeenRead { get; set; }

        public NotificationViewModel(UserMessage userMessage)
        {
            Message message = userMessage.Message;
            Id = message.Id;
            Name = message.Name;
            Content = message.Content;
            Type = message.Type;
            HasBeenRead=userMessage.HasBeenRead;
            OrganizerId = message.Organizer?.OrganizerId;
            EventName = message.Event?.Name;
            EventId = message.Event?.Id;
        }
    }
}