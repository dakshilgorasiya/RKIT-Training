using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Runtime.Caching;
using System.Net.Http.Headers;
using CachingDemo.Attributes;

namespace CachingDemo.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            ObjectCache cache = MemoryCache.Default;

            string cacheKey = "uniqueKey";

            string[] response = cache[cacheKey] as string[];

            if (response != null)
            {
                return new string[] { response[0], "Cache hit" };
            }
            
            // add if not exists, update else
            cache.Set(cacheKey, new string[] { "value1", "value2" }, DateTimeOffset.Now.AddMinutes(1));


            // other methods
            // Add -> add only if not already exists
            // AddOrGetExisting -> add if not exists else return existsing value
            // Contain -> check if key exists
            // CreateCacheEntryChangeMonitor -> to create cache moniors, pass an array of keys if they change, remove, add it will remove current cache, it can be added in policy.ChangeMonitors.Add
            // Dispose -> to free resourses
            // Get -> to fetch entry
            // GetCacheItem -> to fetch entire cacheitem
            // GetCount -> return total number of cache entry
            // GetEnumerator -> enumerate over key value pairs
            // GetValues -> to fetch multiple entries at a time
            // Remove -> to remove entry
            // Trim -> to remove given percentage of entries (Use Lease recently used)


            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public IHttpActionResult Get(int id)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, "value");

            response.Headers.CacheControl = new CacheControlHeaderValue()
            {
                Public = true,
                MaxAge = TimeSpan.FromMinutes(10),
            };
            return ResponseMessage(response);
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
