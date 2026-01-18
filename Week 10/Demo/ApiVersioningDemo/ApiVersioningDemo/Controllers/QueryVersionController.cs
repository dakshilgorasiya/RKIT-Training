using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiVersioningDemo.Controllers
{
    /// <summary>
    /// A controller that demonstrates query string-based API versioning.
    /// </summary>
    public class QueryVersionController : ApiController
    {
        /// <summary>
        /// A simple GET endpoint that returns different responses based on the API version specified in the query string.
        /// </summary>
        /// <returns>TEXT</returns>
        [HttpGet]
        public IHttpActionResult Get()
        {
            // Get query parameters from the request
            IEnumerable<KeyValuePair<string, string>> query = Request.GetQueryNameValuePairs();

            // Extract the version from query parameters
            var versionParam = query.FirstOrDefault(q => q.Key == "api-version").Value;

            // Return response based on version
            if (versionParam == "1")
            {
                return Ok("V1");
            }
            else if(versionParam == "2")
            {
                return Ok("V2");
            }
            else
            {
                return Ok("Invalid version");
            }
        }
    }
}
