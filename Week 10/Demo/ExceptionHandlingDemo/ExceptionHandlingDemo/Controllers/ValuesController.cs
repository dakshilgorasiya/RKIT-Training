using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ExceptionHandlingDemo.Exceptions;
using ExceptionHandlingDemo.Filters;

namespace ExceptionHandlingDemo.Controllers
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
        public void Post([FromBody] string value)
        {
            // Will not send stacktrace
            throw new HttpResponseException(
                    Request.CreateResponse(
                            HttpStatusCode.Forbidden,
                            new { message = "Access denied" }
                        )
                );
        }

        // To enable only for this action
        // [GlobalExceptionFilter]
        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
            throw new Exception("Not allowed");
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            throw new InvalidValueException("Value should be positive");
        }
    }
}
