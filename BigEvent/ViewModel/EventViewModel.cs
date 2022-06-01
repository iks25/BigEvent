using BigEvent.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BigEvent.ViewModel
{
    public class EventViewModel
    {
        public int CopiedId { get; set; }

        [StringLength(150)]
        [Required]
        public string Name { get; set; }



        [Required]
        [DataType(DataType.Date)]
        public string Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public string Time { get; set; }
        public DateTime DateTime { get; set; }

        [Required]
        public string Address { get; set; }

        public List<SelectListItem> Types { get; set; }
        public int EventType { get; set; }
        public float TicketPrice { get; set; }
        public List<Image> ImagesInGallery { get; set; }

        public int ChosenImageId { get; set; }
        public string ChosenImageSrc { get; set; }
        public string ChosenImageName { get; }
        public string Description { get; set; }


        public EventViewModel()
        {

        }
        public EventViewModel(Event @event, List<SelectListItem> eventsTypes, List<Image> images)
        {
            CopiedId = @event.Id;
            Name = @event.Name;
            Time = @event.DateTime.ToString("HH:mm");
            Date = @event.DateTime.Date.ToString();
            DateTime = @event.DateTime;
            Address = @event.Address;
            EventType = @event.EventTypeId;
            TicketPrice = @event.TicketPrice;
            ChosenImageId = @event.ImageId;
            ChosenImageSrc = @event.Image.Src;
            ChosenImageName = @event.Image.Name;
            Description = @event.Description;


            ImagesInGallery = images;
            Types = eventsTypes;


        }
    }
}
