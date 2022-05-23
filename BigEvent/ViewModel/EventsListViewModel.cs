using BigEvent.Models;

namespace BigEvent.ViewModel
{
    public class EventsListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OrganizerName { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
        public string DateOfTheWeek { get; set; }
        public string HostName { get; set; }

        public EventsListViewModel(Event eventEntity)
        {
            Id = eventEntity.Id;
            Name = eventEntity.Name;
            Time = eventEntity.DateTime.TimeOfDay.ToString();
            Date = eventEntity.DateTime.Date.ToString();
            DateOfTheWeek = eventEntity.DateTime.DayOfWeek.ToString();
            HostName = eventEntity.Organizer.UserName;

        }
    }


}
