using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RedisDemo.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        private readonly IDatabase _redis;

        public ValuesController()
        {
            _redis = RedisConnectionHelper.Connection.GetDatabase();
        }

        public IHttpActionResult Get()
        {
            string cacheKey = "ValueData";

            // To get value by key
            var cachedData = _redis.StringGet(cacheKey);

            // To delete data using key
            //_redis.KeyDelete(cacheKey);

            if (cachedData.HasValue)
            {
                return Ok(Newtonsoft.Json.JsonConvert.DeserializeObject(cachedData));
            }

            var values = new[] { "value1", "value2", "value3" };

            // To set data in redis
            _redis.StringSet(
                    cacheKey,
                    Newtonsoft.Json.JsonConvert.SerializeObject(values),
                    TimeSpan.FromSeconds(60)
                );

            return Ok(values);
        }

        // GET api/values/5
        public string Get(int id)
        {
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
