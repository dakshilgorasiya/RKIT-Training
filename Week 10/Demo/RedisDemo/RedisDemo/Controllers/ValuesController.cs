using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RedisDemo.Controllers
{
    /// <summary>
    /// A simple API controller to demonstrate Redis caching.
    /// </summary>
    public class ValuesController : ApiController
    {
        // Redis database instance   
        private readonly IDatabase _redis;

        // GET api/values
        // Constructor to initialize Redis connection
        public ValuesController()
        {
            // Get Redis database instance
            _redis = RedisConnectionHelper.Connection.GetDatabase();
        }

        /// <summary>
        /// A simple GET method to demonstrate Redis caching.
        /// </summary>
        /// <returns>200</returns>
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
