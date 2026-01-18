using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiVersioningDemo.Controllers
{
    /// <summary>
    /// A version 2 API controller for data operations.
    /// </summary>
    [RoutePrefix("api/v2/data")]
    public class DataV2Controller : ApiController
    {
        /// <summary>
        /// Handles HTTP GET requests for the root route of the controller.
        /// </summary>
        /// <returns>Hi from v2</returns>
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok("HI from v2");
        }
    }
}
