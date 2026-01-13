using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace TodoListDemo.Handlers
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            context.Result = new ResponseMessageResult(
                    context.Request.CreateErrorResponse(
                            HttpStatusCode.InternalServerError,
                            context.Exception.Message
                        )
                );
        }
    }
}