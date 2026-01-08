using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiVersioningDemo.Controllers
{
    public class HeaderVersionController : ApiController
    {
        public IHttpActionResult Get()
        {
            IEnumerable<string> versionHeaders;

            if (!Request.Headers.TryGetValues("X-API-Version", out versionHeaders))
            {
                return BadRequest("API version header missing");
            }

            var version = versionHeaders.FirstOrDefault();

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
