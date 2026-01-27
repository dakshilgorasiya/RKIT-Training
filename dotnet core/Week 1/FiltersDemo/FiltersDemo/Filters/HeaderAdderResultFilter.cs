using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

namespace FiltersDemo.Filters
{
    public class HeaderAdderResultFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            if (context.Result is ObjectResult objectResult)
            {
                string json = JsonSerializer.Serialize(objectResult.Value);
                Console.WriteLine($"Action Result executed: {json}");
            }
            else
            {
                Console.WriteLine("Action Result executed, but not an ObjectResult");
            }
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("X-Version", "1");
            Console.WriteLine("Header added");
        }
    }
}
