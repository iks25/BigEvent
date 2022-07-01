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
            Event currentEvent = GetFullEvent(id);

            if (currentEvent == null)
            {
                var message = "event with that id does not exist";
                return RedirectToAction(
                    "ExpectedError",
                    "Home",
                    new { message = message });
            }


            var eventVM = new EventDescriptionVM(currentEvent);


            return View(eventVM);
        }



        [Authorize]
        public IActionResult DescriptionForOwner(int id)
        {
            Event currentEvent = GetFullEvent(id);
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
                var message = "you are not owner of that event";
                return RedirectToAction(
                    "ExpectedError",
                    "Home",
                    new { message = message });
            }


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
            //todo only for organizer
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

            return RedirectToAction("My", "EventsList");
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(EventViewModel eventVm)
        {
            Organizer organizer = OrganizerHelper.GetCurrnetOrganizer(User, _dbContext);
            var @event = _dbContext.Events.SingleOrDefault(e => e.Id == eventVm.CopiedId);

            if (organizer == null || @event == null
                || @event.OrganizerId != organizer.OrganizerId)
            {
                var message = "you can not edit this Event";
                return RedirectToAction(
                    "ExpectedError",
                    "Home",
                    new { message = message });
            }

            @event.Name = eventVm.Name;
            @event.EventTypeId = eventVm.EventType;
            @event.DateTime = eventVm.DateTime;
            @event.Address = eventVm.Address;
            @event.ImageId = eventVm.ChosenImageId;
            @event.TicketPrice = eventVm.TicketPrice;
            @event.Description = eventVm.Description;

            var messageFactory = new MessageFactory();
            
            var editMessage = messageFactory.CreateEditMessage(@event, organizer);
            _dbContext.Messages.Add(editMessage);
            
            var followersId =
                _dbContext.EventsInCalendar
                .Where(e => e.EventId == @event.Id)
                .Select(e=>e.UserId);

            foreach (var item in followersId)
            {
                _dbContext.UserMessages
                    .Add(
                        new UserMessage()
                        {
                            Message = editMessage,
                            BasicUserId = item,
                            HasBeenRead = false
                        }
                    );
            }
            _dbContext.SaveChanges();

            return RedirectToAction("DescriptionForOwner", new { id = eventVm.CopiedId });
        }


        [Authorize]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var organizeID = OrganizerHelper.GetCurrnetOrganizer(User, _dbContext).OrganizerId;
            var @event = _dbContext.Events
                .SingleOrDefault
                (e => e.Id == id && e.OrganizerId == organizeID);
            if (@event == null)
            {
                return BadRequest(new { meesage = "you ca not delete this Event" });
            }
            _dbContext.Events.Remove(@event);
            _dbContext.SaveChanges();
            return Ok();
        }




        [HttpGet]
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
            var viewItem = new EventViewModel
                (currentEvent, listSelectedItems, images);


            return View(viewItem);

        }

        private Event GetFullEvent(int id)
        {
            return _dbContext.Events
                .Include(e => e.Organizer)
                .Include(e => e.Image)
                .Include(e => e.Type)
                .SingleOrDefault(e => e.Id == id);
        }

      
    }
}
