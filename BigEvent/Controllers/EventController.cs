using BigEvent.Data;
using BigEvent.Models;
using BigEvent.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace BigEvent.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public EventController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Create()
        {
            var listSelectedItems = new List<SelectListItem>();
            _dbContext.EventTypes.ToList().ForEach(eventType =>
            {
                listSelectedItems
                .Add(new SelectListItem()
                {
                    Value = eventType.Id + "",
                    Text = eventType.Name
                });

            });
            var images = _dbContext.Images.ToList<Image>();
            var viewItem = new EventViewModel()
            {
                Types = listSelectedItems,
                ImagesInGallery = images

            };

            return View(viewItem);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Create(EventViewModel eventVM)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId    

            var organize = _dbContext.Organizers.Single(user => user.ApplicationDbContextId == userId);

            var newEvent = new Event()
            {
                Name = eventVM.Name,
                EventTypeId = eventVM.EventType,
                DateTime = DateTime.Parse($"{eventVM.Date} {eventVM.Time}"),
                Address = eventVM.Address,
                Organizer = organize,
                ImageId = eventVM.ChosenImageId
            };

            _dbContext.Events.Add(newEvent);
            _dbContext.SaveChanges();
            return Content("done");
        }
    }
}
