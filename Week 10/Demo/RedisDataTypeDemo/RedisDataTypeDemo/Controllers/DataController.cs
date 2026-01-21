using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RedisDataTypeDemo.Controllers
{
    [RoutePrefix("api/v1/data")]
    public class DataController : ApiController
    {
        IDatabase redisDb = RedisConnectionHelper.Connection.GetDatabase();

        [Route("string")]
        [HttpGet]
        public string StringType()
        {
            RedisValue cachedData = redisDb.StringGet("string");

            if (cachedData == RedisValue.Null)
            {
                redisDb.StringSet("string", "HELLO");
                return "CACHE MISS";
            }
            else
            {
                redisDb.KeyDelete("string");
                return cachedData.ToString();
            }
        }

        [Route("hash")]
        [HttpGet]
        public IHttpActionResult HashType()
        {
            HashEntry[] cachedData = redisDb.HashGetAll("hash");
            if (cachedData.Length != 0)
            {
                redisDb.KeyDelete("hash");
                return Ok(cachedData);
            }
            else
            {
                redisDb.HashSet("hash", new HashEntry[]
                {
                    new HashEntry("id", 1),
                    new HashEntry("name", "abc")
                });
                return Ok("Cache miss");
            }
        }

        [Route("list")]
        [HttpGet]
        public IHttpActionResult ListType()
        {
            RedisValue cachedData = redisDb.ListLeftPop("list");
            if (cachedData != RedisValue.Null)
            {
                return Ok(cachedData);
            }
            else
            {
                redisDb.ListRightPush("list", "1");
                return Ok("Cache miss");
            }
        }

        [Route("set")]
        [HttpGet]
        public IHttpActionResult SetType()
        {
            bool isExits = redisDb.SetContains("set", "1");

            if (isExits)
            {
                redisDb.SetRemove("set", "1");
                return Ok("Cache hit");
            }
            else
            {
                redisDb.SetAdd("set", "1");
                return Ok("Cache miss");
            }
        }

        [Route("SortedSet")]
        [HttpGet]
        public IHttpActionResult SortedSetType()
        {
            long count = redisDb.SortedSetLength("sortedSet");

            if (count > 0)
            {
                var cachedData = redisDb.SortedSetRangeByRank("sortedSet", 1, 3);
                redisDb.KeyDelete("sortedSet");
                return Ok(cachedData);
            }
            else
            {
                redisDb.SortedSetAdd("sortedSet", "a", 10);
                redisDb.SortedSetAdd("sortedSet", "b", 20);
                redisDb.SortedSetAdd("sortedSet", "c", 30);
                redisDb.SortedSetAdd("sortedSet", "d", 40);
                redisDb.SortedSetAdd("sortedSet", "e", 50);
                redisDb.SortedSetAdd("sortedSet", "f", 60);
                redisDb.SortedSetAdd("sortedSet", "g", 70);
                return Ok("Cache miss");
            }
        }
    }
}
