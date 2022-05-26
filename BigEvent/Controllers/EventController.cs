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
            var viewItem = new EventViewModel() { Types = listSelectedItems };

            return View(viewItem);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Create(EventViewModel eventViewModel)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId    
            //TODO find Organizer by userId
            var organize = _dbContext.Organizers.Single(user => user.ApplicationDbContextId == userId);

            var newEvent = new Event()
            {
                Name = eventViewModel.Name,
                EventTypeId = eventViewModel.EventType,
                DateTime = DateTime.Parse($"{eventViewModel.Date} {eventViewModel.Time}"),
                Address = eventViewModel.Address,
                Organizer = organize
            };

            _dbContext.Events.Add(newEvent);
            _dbContext.SaveChanges();
            return Content("done");
        }
    }
}
