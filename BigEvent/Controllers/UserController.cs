using BigEvent.Data;
using BigEvent.filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BigEvent.Controllers
{
    [Authorize]
    [TypeFilter(typeof(OnlyForBasicUserFilter))]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }
        // GET
        
        
        public IActionResult Saved()
        {
            return View();
        }

        public IActionResult Calendar()
        {
            return View();
        }
    }
}