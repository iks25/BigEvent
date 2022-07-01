using System;
using BigEvent.Controllers;
using BigEvent.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BigEvent.filters
{
    public class OnlyForBasicUserFilter:Attribute,IActionFilter
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public OnlyForBasicUserFilter(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
            var controller = context.Controller as ControllerBase;
            var identityHelper = new UserIdentityHelper(_dbContext, _userManager, controller.User);


            if (!identityHelper.isBasicUser())
            {
                const string textMessage = "only basic user can use that page";
                context.Result = new RedirectToActionResult(
                    "ExpectedError",
                    "Home",
                    new {message=textMessage}
                );
            }


        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //Todo handle changing organizer 
            // throw new NotImplementedException();
        }
    }
}