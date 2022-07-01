using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BigEvent.filters
{
    public class OnlyForOrganizerFilter:Attribute,IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //todo handle only for organizer
            throw new NotImplementedException();
        }
    }
}