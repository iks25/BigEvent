using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BigEvent.ViewModel
{
    public class EventViewModel
    {
        [StringLength(150)]
        [Required]
        public string Name { get; set; }



        [Required]
        [DataType(DataType.Date)]
        public string Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public string Time { get; set; }


        public List<SelectListItem> Types { get; set; }
        public int EventType { get; set; }
        public float TicketPrice { get; set; }
    }
}
