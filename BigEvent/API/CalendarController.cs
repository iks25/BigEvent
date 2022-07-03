using BigEvent.Controllers;
using BigEvent.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BigEvent.repository;

namespace BigEvent.API
{
    [Route("api/[controller]")]
    [ApiController]
    /*[Authorize]*/
    public class CalendarController : ControllerBase
    {
        /*        private UserIdentityHelper _userIdentityHelper;
        */
        private ApplicationDbContext _dbContext;
        private UserManager<ApplicationUser> _userManager;
        private readonly CalendarRepository _calendarRepository;

        public CalendarController(ApplicationDbContext dbContext,
            UserManager<ApplicationUser> userManager,
            CalendarRepository calendarRepository)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _calendarRepository = calendarRepository;
        }

        // POST: api/TodoItems
        [HttpPost()]
        [Route("addEvent/{eventId}")]
        [Authorize]
        public IActionResult AddEvent(int eventId)
        {
            var userIdentityHelper =
                new UserIdentityHelper(_dbContext, _userManager, User);


            if (!userIdentityHelper.isBasicUser())
            {
                var message = "Only Basic User Can Use that action";
                return RedirectToAction(
                    "ExpectedError",
                    "Home",
                    new { message = message });
            }

            var currentEvent = _dbContext.Events.SingleOrDefault(e => e.Id == eventId);

            if (currentEvent == null)
            {
                var message = "that Event do not exit";
                return RedirectToAction(
                    "ExpectedError",
                    "Home",
                    new { message = message });

            }
            _dbContext.EventsInCalendar
                .Add(new Models.EventInCalendar()
                {
                    Event = currentEvent,
                    User = userIdentityHelper.BasicUser
                });

            //check if exist in database
            _dbContext.SaveChanges();
            return Ok();
        }

        // POST: api/TodoItems
        [HttpDelete()]
        [Route("DeleteEvent/{eventId}")]
        public IActionResult DeleteEvent(int eventId)
        {
            var userIdentityHelper =
                new UserIdentityHelper(_dbContext, _userManager, User);


            if (!userIdentityHelper.isBasicUser())
            {
                var message = "Only Basic User Can Use that action";
                return RedirectToAction(
                    "ExpectedError",
                    "Home",
                    new { message = message });
            }
            var userId = userIdentityHelper.BasicUserId;
            var eventInCalendar =
                _dbContext.EventsInCalendar
                .SingleOrDefault
                (e => e.EventId == eventId && e.UserId == userId);
            _dbContext.EventsInCalendar.Remove(eventInCalendar);
            _dbContext.SaveChanges(true);

            return Ok();
        }

        [HttpGet]
        [Route("EventInCalendar")]
        [Authorize]
        public IActionResult GetEventsCalendar()
        {
            var userIdentityHelper =
                new UserIdentityHelper(_dbContext, _userManager, User);
            if (!userIdentityHelper.isBasicUser())
            {
                return Unauthorized();
            }
            
            
            var userId = userIdentityHelper.BasicUserId;

            var events =
                _calendarRepository.GetUserFullEvent(userId).ToList();

            
            return Ok(events);
        }

    }
}
