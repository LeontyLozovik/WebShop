using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebShop.Filters
{
    public class ValidateId : IActionFilter
    {
        private ILogger<ValidateId> _logger;
        public ValidateId(ILogger<ValidateId> logger)
        { 
            _logger = logger;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        { }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var action = context.RouteData.Values["action"];
            var controller = context.RouteData.Values["controller"];
            var param = context.ActionArguments.SingleOrDefault(x => x.Value is Guid).Value;

            if (param == null)
            {
                _logger.Log(LogLevel.Error, $"Object sent from client is null. Controller: {controller}, action: {action}");
                context.HttpContext.Items.Add("error", true);
                return;
            }
            context.HttpContext.Items.Add("error", false);
        }
    }
}
