using Microsoft.AspNetCore.Mvc;

namespace BigEvent.Controllers
{
    public class TestController : Controller
    {

        public IActionResult Index(int id)
        {
            return Content($"z id {id}");
        }
    }
}
