using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPI1.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [EnableCors(origins: "http://127.0.0.1:5503", headers:"*", methods:"*")]
        public string Post([FromBody] string value)
        {
            return "OK";
        }

        // PUT api/values/5
        public string Put(int id, [FromBody] string value)
        {
            return "OK";
        }

        // DELETE api/values/5
        public string Delete(int id)
        {
            return "OK";
        }
    }
}
