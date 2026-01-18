using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace TodoListDemo.Handlers
{
    /// <summary>
    /// A global exception handler to catch unhandled exceptions
    /// </summary>
    public class GlobalExceptionHandler : ExceptionHandler
    {
        /// <summary>
        /// A method to handle unhandled exceptions
        /// </summary>
        /// <param name="context">Context of exception</param>
        public override void Handle(ExceptionHandlerContext context)
        {
            // Create generic error response
            context.Result = new ResponseMessageResult(
                    context.Request.CreateErrorResponse(
                            HttpStatusCode.InternalServerError,
                            context.Exception.Message
                        )
                );
        }
    }
}