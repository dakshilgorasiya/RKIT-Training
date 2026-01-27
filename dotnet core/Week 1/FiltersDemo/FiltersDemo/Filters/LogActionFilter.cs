using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace FiltersDemo.Filters
{
    public class LogActionFilter : IActionFilter
    {
        private Stopwatch _stopwatch = new();
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatch.Stop();
            Console.WriteLine($"Action '{context.ActionDescriptor.DisplayName}' executed in {_stopwatch.ElapsedMilliseconds} ms");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _stopwatch.Start();
            Console.WriteLine($"Action '{context.ActionDescriptor.DisplayName}' executing at {DateTime.Now}");
        }
    }
}
