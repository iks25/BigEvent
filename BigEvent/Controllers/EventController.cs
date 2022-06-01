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
                ImageId = eventVM.ChosenImageId,
                TicketPrice = eventVM.TicketPrice,
                Description = eventVM.Description,

            };

            _dbContext.Events.Add(newEvent);
            _dbContext.SaveChanges();
            return Content("done");
        }
        [Authorize]
        public IActionResult Delete(int id)
        {
            //TODO ADD DELETE
            return Content("delete " + id);
        }

        [Authorize]
        public IActionResult Edit(int id)
        {


            var currentEvent = _dbContext.Events
                .Include(e => e.Organizer)
                .Include(e => e.Image)
                .Include(e => e.Type)
                .FirstOrDefault(e => e.Id == id);

            if (currentEvent == null)
            {
                var message = "event with that id does not exist";
                return RedirectToAction(
                    "ExpectedError",
                    "Home",
                    new { message = message });

            }

            var currentOrganizerId =
                OrganizerHelper
                .GetCurrnetOrganizer(User, _dbContext)
                .OrganizerId;

            if (currentEvent.OrganizerId != currentOrganizerId)
            {
                var message = "you can not edit Event what is not your";
                return RedirectToAction(
                    "ExpectedError",
                    "Home",
                    new { message = message });
            }



            //TODO ADD EDIT
            //todo my event retun to my list

            return Content("Edit " + id);
        }
    }
}
