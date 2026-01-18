using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiVersioningDemo.Controllers
{
    /// <summary>
    /// A version 1 API controller for data operations.
    /// </summary>
    [RoutePrefix("api/v1/data")]
    public class DataV1Controller : ApiController
    {
        /// <summary>
        /// A simple GET endpoint that returns a greeting message.
        /// </summary>
        /// <returns>HI</returns>
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok("HI");
        }
    }
}
