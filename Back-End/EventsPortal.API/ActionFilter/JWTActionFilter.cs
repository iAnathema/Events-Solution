using EventsPortal.API.DTO;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EventsPortal.API.ActionFilter
{
    public class JWTActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            JWTInfos.Init(context.HttpContext.User);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //code here runs after the action method executes
        }
    }
}
