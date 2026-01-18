using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiVersioningDemo.Controllers
{
    /// <summary>
    /// A controller that demonstrates header-based API versioning.
    /// </summary>
    public class HeaderVersionController : ApiController
    {
        /// <summary>
        /// A simple GET endpoint that returns different responses based on the API version specified in the request header.
        /// </summary>
        /// <returns>TEXT</returns>
        public IHttpActionResult Get()
        {
            // Get headers from the request
            IEnumerable<string> versionHeaders;
            if (!Request.Headers.TryGetValues("X-API-Version", out versionHeaders))
            {
                return BadRequest("API version header missing");
            }

            // Extract the version from headers
            var version = versionHeaders.FirstOrDefault();

            // Return response based on version
            if (version == "1")
            {
                return Ok("V1");
            }
            else if (version == "2")
            {
                return Ok("V2");
            }
            else
            {
                return Ok("Invalid API version");
            }
        }
    }
}
