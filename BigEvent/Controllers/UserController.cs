using System.Linq;
using BigEvent.Data;
using BigEvent.filters;
using BigEvent.repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BigEvent.Controllers
{
    [Authorize]
    [TypeFilter(typeof(OnlyForBasicUserFilter))]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly CalendarRepository _calendarRepository;

        public UserController(
            ApplicationDbContext dbContext,
            UserManager<ApplicationUser> userManager,
            CalendarRepository calendarRepository)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _calendarRepository = calendarRepository;
        }
        // GET
        
        
        public IActionResult Saved()
        {
            var userIdentityHelper =
                new UserIdentityHelper(_dbContext, _userManager, User);
            var userId = userIdentityHelper.BasicUserId;

            var events =
                _calendarRepository.GetUserFullEvent(userId).ToList();
            
            return View(events);
        }

        public IActionResult Calendar()
        {
            var userIdentityHelper =
                new UserIdentityHelper(_dbContext, _userManager, User);
            var userId = userIdentityHelper.BasicUserId;

            var events =
                _calendarRepository.GetUserFullEvent(userId).ToList();
            
            return View(events);
        }
        
        
    }
}