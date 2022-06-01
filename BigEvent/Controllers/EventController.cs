using BigEvent.Data;
using BigEvent.Models;
using BigEvent.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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


        public IActionResult Description(int id)
        {

            var id2 = id + 3;
            var currentEvent = _dbContext.Events
                .Include(e => e.Organizer)
                .Include(e => e.Image)
                .Include(e => e.Type)
                .SingleOrDefault(e => e.Id == id);

            if (currentEvent == null)
                return NotFound();
            //TODO Redirect Message

            var eventVM = new EventDescriptionVM(currentEvent);


            return View(eventVM);
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
            Organizer organize = OrganizerHelper.GetCurrnetOrganizer(User, _dbContext);

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

        //private Organizer GetCurrnetOrganizer()
        //{
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId    

        //    var organize = _dbContext.Organizers.Single(user => user.ApplicationDbContextId == userId);
        //    return organize;
        //}
    }
}
