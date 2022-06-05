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
    public class AttendanceController : ControllerBase
    {
        private UserIdentityHelper userIdentityHelper;
        private ApplicationDbContext _dbContext;

        public AttendanceController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            this.userIdentityHelper = new UserIdentityHelper(_dbContext, userManager, User);
        }



        // POST: api/TodoItems
        [HttpPost()]
        [Route("add/{eventId}")]
        public IActionResult AddAttendance(int eventId)
        {
            //TODo handle add attend
            return Content("-> " + eventId);

        }

    }
}
