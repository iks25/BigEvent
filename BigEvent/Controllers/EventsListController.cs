using System.Collections.Generic;
using System.Linq;
using BigEvent.Data;
using BigEvent.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigEvent.Controllers
{
    public class EventsListController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public EventsListController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var eventList = new List<EventsListViewModel>();

            var eventListFromDb =
                _dbContext.Events.Include(e => e.Organizer).Include(e => e.Image).Include(e => e.Type);



            foreach (var item in eventListFromDb)
            {
                eventList.Add(new EventsListViewModel(item));
            }


            if (_signInManager.IsSignedIn(User))
            {
                var identityHelper = new UserIdentityHelper(_dbContext, _userManager, User);

                if (identityHelper.isBasicUser())
                {
                    var userId = identityHelper.BasicUserId;
                    foreach (var item in eventList)
                    {
                        var eventinCalendar = _dbContext
                            .EventsInCalendar
                            .SingleOrDefault
                            (i => i.UserId == userId && i.EventId == item.Id);
                        if (eventinCalendar != null)
                        {
                            item.IsInCalendar = true;
                        }

                    }
                }


            }


            return View(eventList);
        }
        [Authorize]
        public IActionResult My()
        {
            //TODO redirect when user not exist
            var organizer = OrganizerHelper
                .GetCurrnetOrganizer(User, _dbContext);


            var eventList = new List<EventsListViewModel>();
            var eventListFromDb =
                _dbContext.Events.Include(e => e.Organizer).Include(e => e.Image).Include(e => e.Type)
                .Where(e => e.OrganizerId == organizer.OrganizerId);


            foreach (var item in eventListFromDb)
            {
                eventList.Add(new EventsListViewModel(item));
            }




            return View(eventList);
        }
    }
}
