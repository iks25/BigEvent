using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigEvent.Controllers
{
    public class EventTypeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
