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
    /// <summary>
    /// A global exception filter to handle exceptions thrown by Web API actions.
    /// </summary>
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        /// <summary>
        /// A method that is called when an exception is thrown by a Web API action.
        /// </summary>
        /// <param name="context">Context of request</param>
        public override void OnException(HttpActionExecutedContext context)
        {
            // Handle specific exception types
            if (context.Exception is InvalidValueException)
            {
                // Return a 400 Bad Request response with the exception message
                context.Response = context.Request.CreateErrorResponse(
                        HttpStatusCode.BadRequest,
                        context.Exception.Message
                    );
            }
            else
            {
                // For other exceptions, return a 500 Internal Server Error response
                context.Response = context.Request.CreateErrorResponse(
                    HttpStatusCode.InternalServerError,
                    "An unexpected error occured"
                );
            }
        }
    }
}