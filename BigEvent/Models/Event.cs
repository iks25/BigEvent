using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace BigEvent.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        public IdentityUser User { get; set; }
        
        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public EventType Type { get; set; }
        public float TicketPrice { get; set; }
    }
}
