using DependencyInjectionDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DependencyInjectionDemo.Controllers
{
    public class ValuesController : ApiController
    {
        // Dependency injection via constructor
        private readonly IMessageService _messageService;

        public ValuesController(IMessageService messageService)
        {
            // Assign the injected service to a private field
            _messageService = messageService;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            // Use the injected service to get a message
            return _messageService.GetMessage();
        }

        // POST api/values
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
