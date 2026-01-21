using FiltersDemo.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FiltersDemo.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        //[JwtAuthenticationFilter]
        //[RoleAuthorizationFilter("admin")]
        [OverrideFilter]
        public IEnumerable<string> Get()
        {
            System.Diagnostics.Debug.WriteLine("Action executed");
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [LogActionFilter2]
        [GlobalExceptionFilter2]
        
        public string Get(int id)
        {
            throw new Exception("DB not connected");
            return "value";
        }

        // POST api/values
        [OverrideFilter]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
