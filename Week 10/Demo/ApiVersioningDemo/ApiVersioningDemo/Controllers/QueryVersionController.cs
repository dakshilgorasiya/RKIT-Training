using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiVersioningDemo.Controllers
{
    public class QueryVersionController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            var query = Request.GetQueryNameValuePairs();
            var versionParam = query.FirstOrDefault(q => q.Key == "api-version").Value;

            if(versionParam == "1")
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
