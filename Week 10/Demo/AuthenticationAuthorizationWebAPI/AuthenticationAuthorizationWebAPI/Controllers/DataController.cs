using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace AuthenticationAuthorizationWebAPI.Controllers
{
    [RoutePrefix("api/data")]
    public class DataController : ApiController
    {
        /// <summary>
        /// Secured api
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("secured")]
        public IHttpActionResult GetSecuredData()
        {
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            return Ok(identity.FindFirst(ClaimTypes.Role).Value);
        }

        /// <summary>
        /// Admin only api
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("admin-only")]
        public IHttpActionResult GetAdminData()
        {
            return Ok("Welcome, Admin");
        }
    }
}
