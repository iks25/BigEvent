using BigEvent.Data;
using BigEvent.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BigEvent.Controllers
{
    public class EventsListController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public EventsListController(ApplicationDbContext dbContext)
        {
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
