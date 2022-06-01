using BigEvent.Models;
using System;

namespace BigEvent.ViewModel
{
    public class EventDescriptionVM
    {
        public int Id { get; set; }


        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string OrganizerName { get; set; }
        public string OrganizerImgSrc { get; set; }
        public DateTime DateTime { get; set; }
        public string TypeName { get; set; }
        public string ImageSrc { get; set; }
        public float TicketPrice { get; set; }


        public EventDescriptionVM(Event _event)
        {
            Id = _event.Id;
            Name = _event.Name;
            Address = _event.Address;
            Description = _event.Description;
            OrganizerName = _event.Organizer.Name;
            OrganizerImgSrc = _event.Organizer.ImgLink;
            DateTime = _event.DateTime;
            TypeName = _event.Type.Name;
            ImageSrc = _event.Image.Src;
            TicketPrice = _event.TicketPrice;
        }


    }
}
