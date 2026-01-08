using CachingDemo.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CachingDemo.Controllers
{
    [RoutePrefix("api/data")]
    public class DataController : ApiController
    {
        [System.Web.Http.HttpGet]
        [CacheHeader(Duration = 300)]
        [Route("GetData")]
        public string getData()
        {
            return "value";
        }

        [System.Web.Http.HttpGet]
        [Route("GetETag")]
        public HttpResponseMessage getEtagData()
        {
            var currentEtag = "\"prod-10-v2\"";

            if(Request.Headers.IfNoneMatch.Any(e => e.Tag == currentEtag))
            {
                return new HttpResponseMessage(HttpStatusCode.NotModified);
            }

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
