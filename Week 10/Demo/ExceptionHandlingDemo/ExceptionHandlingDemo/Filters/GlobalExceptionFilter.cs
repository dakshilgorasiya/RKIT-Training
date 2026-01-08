using ExceptionHandlingDemo.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace ExceptionHandlingDemo.Filters
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is InvalidValueException)
            {
                context.Response = context.Request.CreateErrorResponse(
                        HttpStatusCode.BadRequest,
                        context.Exception.Message
                    );
            }
            else
            {
                context.Response = context.Request.CreateErrorResponse(
                    HttpStatusCode.InternalServerError,
                    "An unexpected error occured"
                );
            }
        }
    }
}