using CachingDemo.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CachingDemo.Controllers
{
    /// <summary>
    /// A simple API controller demonstrating caching mechanisms.
    /// </summary>
    [RoutePrefix("api/data")]
    public class DataController : ApiController
    {
        /// <summary>
        /// A simple GET endpoint that returns a string value with caching headers.
        /// </summary>
        /// <returns>TEXT</returns>
        [System.Web.Http.HttpGet]
        [CacheHeader(Duration = 300)]
        [Route("GetData")]
        public string getData()
        {
            return "value";
        }

        /// <summary>
        /// A GET endpoint that demonstrates ETag-based caching.
        /// </summary>
        /// <returns>203 if not modified, 200 else</returns>
        [System.Web.Http.HttpGet]
        [Route("GetETag")]
        public HttpResponseMessage getEtagData()
        {
            var currentEtag = "\"prod-10-v2\"";

            // Check if the request contains an If-None-Match header with the current ETag
            if (Request.Headers.IfNoneMatch.Any(e => e.Tag == currentEtag))
            {
                return new HttpResponseMessage(HttpStatusCode.NotModified);
            }

            // Return the data with the current ETag
            var response = Request.CreateResponse(HttpStatusCode.OK, "value");
            response.Headers.ETag = new System.Net.Http.Headers.EntityTagHeaderValue(currentEtag);
            response.Headers.CacheControl = new System.Net.Http.Headers.CacheControlHeaderValue
            {
                Private = true,
                NoCache = true
            };

            return response;
        }
    }
}
