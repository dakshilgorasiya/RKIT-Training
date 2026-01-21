using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http.Filters;

namespace FiltersDemo.Filters
{
    public class GlobalExceptionFilter: ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            System.Diagnostics.Debug.WriteLine(context.Exception);

            context.Response = context.Request.CreateResponse(
                HttpStatusCode.InternalServerError,
                new
                {
                    Message = "Something went wrong on the server.",
                    Error = context.Exception.Message
                });
        }
    }
}