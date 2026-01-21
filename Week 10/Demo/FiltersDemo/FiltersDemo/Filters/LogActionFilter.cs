using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace FiltersDemo.Filters
{
    public class LogActionFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            System.Diagnostics.Debug.WriteLine($"Action {actionContext.ActionDescriptor.ActionName} starting at {DateTime.Now}");
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            System.Diagnostics.Debug.WriteLine($"Action {actionExecutedContext.ActionContext.ActionDescriptor.ActionName} finished at {DateTime.Now}");
        }
    }
}