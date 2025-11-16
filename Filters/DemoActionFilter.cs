using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;



namespace AspNetMvcDemo.Filters
{
    public class DemoActionFilter : IActionFilter
    {
        private readonly ILogger<DemoActionFilter> _logger;
        public DemoActionFilter(ILogger<DemoActionFilter> logger) => _logger = logger;

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("DemoActionFilter - OnActionExecuting");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("DemoActionFilter - OnActionExecuted");
        }
    }
}
