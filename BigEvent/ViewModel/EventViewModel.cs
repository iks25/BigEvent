using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BigEvent.ViewModel
{
    public class EventViewModel
    {
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        public string Time { get; set; }
        
        public string Data { get; set; }
        public List<SelectListItem> Types { get; set; }
        public int EventType { get; set; }
        public float TicketPrice { get; set; }
    }
}
