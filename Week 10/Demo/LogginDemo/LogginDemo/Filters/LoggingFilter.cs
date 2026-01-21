using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace LogginDemo.Filters
{
    public class LoggingFilter : ActionFilterAttribute
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var request = actionContext.Request;

            var method = request.Method.Method;
            var url = request.RequestUri.ToString();

            logger.Info($"Incoming Request: {method} {url}");
        }
    }
}