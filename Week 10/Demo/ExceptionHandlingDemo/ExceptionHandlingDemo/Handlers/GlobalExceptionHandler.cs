using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace ExceptionHandlingDemo.Handlers
{
    /// <summary>
    /// A global exception handler to handle unhandled exceptions in Web API.
    /// </summary>
    public class GlobalExceptionHandler : ExceptionHandler
    {
        /// <summary>
        /// A method that is called when an unhandled exception occurs.
        /// </summary>
        /// <param name="context">context of request</param>
        public override void Handle(ExceptionHandlerContext context)
        {
            // set a generic error response
            context.Result = new ResponseMessageResult(
                    context.Request.CreateErrorResponse(
                            HttpStatusCode.InternalServerError,
                            "Exception handled globally"
                        )
                );
        }
    }
}