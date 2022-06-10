using System;
using BigEvent.Data;
using BigEvent.Models;

namespace BigEvent.Controllers
{
    public class MessageFactory
    { 
        

        

        public Message CreateEditMessage(Event @event, Organizer organizer)
        {
            var editMessageContent = "Event was Edited";
            return new Message()
            {
                Name = "Edit",
                Content = editMessageContent,
                Organizer = organizer,
                Event = @event,
                Type = MessageType.editMessage
            };
        }

        public Boolean CreateMessage()
        {
            
            return true;
        }
    }
}