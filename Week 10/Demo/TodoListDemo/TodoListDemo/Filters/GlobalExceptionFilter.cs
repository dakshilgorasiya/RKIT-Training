using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using NLog;

namespace TodoListDemo.Filters
{
    /// <summary>
    /// A global exception filter to handle unhandled exceptions
    /// </summary>
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        // NLog Logger
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// A method to handle unhandled exceptions
        /// </summary>
        /// <param name="context">Context of exception</param>
        public override void OnException(HttpActionExecutedContext context)
        {
            // Log the exception
            Logger.Error(context.Exception, $"Unhandled exception in {context.ActionContext.ControllerContext.ControllerDescriptor.ControllerName}.{context.ActionContext.ActionDescriptor.ActionName}");

            // Create a generic error response
            context.Response = context.Request.CreateErrorResponse(
                HttpStatusCode.InternalServerError,
                "An unexpected error occured"
            );
        }
    }
}