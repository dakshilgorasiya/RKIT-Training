using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NLog;
using NLog.Config;

namespace LogginDemo.Controllers
{
    public class ValuesController : ApiController
    {
        // Logger instance
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private readonly Logger _controllerLogger;

        public ValuesController()
        {
            var configPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ValueLogging.config");
            var factory = new LogFactory(new XmlLoggingConfiguration(configPath));
            _controllerLogger = factory.GetLogger("ControllerLogger");
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            // Log an informational message
            _controllerLogger.Info("Get values api called");
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            throw new Exception("Invalid id");
            return "value";
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
