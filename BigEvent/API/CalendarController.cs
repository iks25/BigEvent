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

        public CalendarController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
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
            //TODo handle add attend
            return Content("delete -> " + eventId);
        }

    }
}
