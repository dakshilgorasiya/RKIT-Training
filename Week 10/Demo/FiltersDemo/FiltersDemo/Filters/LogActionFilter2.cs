using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace FiltersDemo.Filters
{
    public class LogActionFilter2 : Attribute, IActionFilter
    {
        public bool AllowMultiple => false;

        public async Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            System.Diagnostics.Debug.WriteLine("Before Action");

            var response = await continuation();

            System.Diagnostics.Debug.WriteLine("After Action");

            return response;
        }
    }
}