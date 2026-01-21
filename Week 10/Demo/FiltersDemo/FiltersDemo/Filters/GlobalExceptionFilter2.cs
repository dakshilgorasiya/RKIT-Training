using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace FiltersDemo.Filters
{
    public class GlobalExceptionFilter2 : Attribute, IExceptionFilter
    {
        public bool AllowMultiple => false;

        public Task ExecuteExceptionFilterAsync(HttpActionExecutedContext context, CancellationToken cancellationToken)
        {
            System.Diagnostics.Debug.WriteLine(context.Exception);

            context.Response = context.Request.CreateErrorResponse(
                HttpStatusCode.InternalServerError,
                "Something went wrong");

            return Task.CompletedTask;
        }
    }
}