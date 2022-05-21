using BigEvent.Data;
using BigEvent.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

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

        public IActionResult Create()
        {
            var listSelectedItems = new List<SelectListItem>();
            _dbContext.EventTypes.ToList().ForEach(eventType =>
            {
                listSelectedItems
                .Add(new SelectListItem()
                {
                    Value = eventType.Name,
                    Text = eventType.Name
                });

            });
            var viewItem = new EventViewModel() { Types = listSelectedItems };

            return View(viewItem);
        }
        [HttpPost]
        public IActionResult Create(EventViewModel eventViewModel)
        {
            var data1 = eventViewModel.Date;
            var time = eventViewModel.Time;
            return Content("test");
        }
    }
}
