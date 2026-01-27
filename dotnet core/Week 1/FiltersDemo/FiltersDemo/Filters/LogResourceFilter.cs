using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersDemo.Filters
{
    public class LogResourceFilter : IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine($"Resouce filter after : {context.HttpContext.Request.Path}");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine($"Resouce filter before : {context.HttpContext.Request.Path}");

            // To short circuit it
            //context.Result = new BadRequestObjectResult(new
            //{
            //    message = "Invalid data"
            //});
        }
    }
}
