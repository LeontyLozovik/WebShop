using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebShop.Filters
{
    public class ValidateModel : IActionFilter
    {
        private ILogger<ValidateModel> _logger;
        public ValidateModel(ILogger<ValidateModel> logger)
        {
            _logger = logger;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var action = context.RouteData.Values["action"];
            var controller = context.RouteData.Values["controller"];
            var param = context.ActionArguments.SingleOrDefault(x => x.Value.ToString().Contains("DTO") 
                            || x.Value.ToString().Contains("Model", StringComparison.OrdinalIgnoreCase)).Value;

            if (param == null)
            {
                _logger.Log(LogLevel.Error, $"Object sent from client is null. Controller: {controller}, action: {action}");
                context.HttpContext.Items.Add("error", true);
                return;
            }

            if (!context.ModelState.IsValid)
            {
                _logger.Log(LogLevel.Error, $"Invalid model state for the object. Controller: {controller}, action: {action}");
                context.HttpContext.Items.Add("error", true);
                return;
            }
            context.HttpContext.Items.Add("error", false);
        }
    }
}
