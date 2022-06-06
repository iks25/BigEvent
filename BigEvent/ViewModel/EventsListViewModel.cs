using BigEvent.Models;
using System;

namespace BigEvent.ViewModel
{
    public class EventsListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OrganizerName { get; set; }
        public DateTime DateTime { get; set; }
        public string DayOfTheWeek { get; set; }
        public string HostName { get; set; }
        public String Type { get; set; }
        public string ImgScr { get; set; }
        public string ImgName { get; set; }
        public float Price { get; set; }

        public bool IsInCalendar { get; set; }

        public EventsListViewModel(Event eventEntity)
        {
            Id = eventEntity.Id;
            Name = eventEntity.Name;
            DayOfTheWeek = eventEntity.DateTime.DayOfWeek.ToString();
            DateTime = eventEntity.DateTime;
            HostName = eventEntity.Organizer.Name;
            Type = eventEntity.Type.Name;
            ImgScr = eventEntity.Image.Src;
            ImgName = eventEntity.Image.Name;
            Price = eventEntity.TicketPrice;




        }
    }


}
