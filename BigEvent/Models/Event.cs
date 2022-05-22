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
        public string Address { get; set; }
        public string Description { get; set; }

        public IdentityUser Organizer { get; set; }

        [Required]
        public string OrganizerId { get; set; }

        [Required]
        public DateTime DateTime { get; set; }


        public EventType Type { get; set; }

        [Required]
        public int EventTypeId { get; set; }


        public float TicketPrice { get; set; }
    }
}
