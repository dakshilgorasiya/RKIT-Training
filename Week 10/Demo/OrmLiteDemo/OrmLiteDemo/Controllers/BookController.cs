using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OrmLiteDemo.Models;
using ServiceStack.OrmLite;

namespace OrmLiteDemo.Controllers
{
    public class BookController : ApiController
    {
        // GET: api/Book
        public IHttpActionResult Get()
        {
            using(var db = WebApiApplication.DbFactory.Open())
            {
                IEnumerable<BokT01> books = db.Select<BokT01>();
                return Ok(books);
            }
        }

        // GET: api/Book/5
        public IHttpActionResult Get(int id)
        {
            using (var db = WebApiApplication.DbFactory.Open())
            {
                BokT01 book = db.SingleById<BokT01>(id);
                if(book == null)
                {
                    return NotFound();
                }
                return Ok(book);
            }
        }

        // POST: api/Book
        public IHttpActionResult Post([FromBody]BokT01 book)
        {
            using(var db = WebApiApplication.DbFactory.OpenDbConnection())
            {
                db.Insert<BokT01>(book);
                return Created<BokT01>("", book);
            }
        }

        // PUT: api/Book/5
        public IHttpActionResult Put([FromBody]BokT01 book)
        {
            using(var db = WebApiApplication.DbFactory.Open())
            {
                bool isFound = db.Exists<BokT01>(b => b.T01F01 == book.T01F01);
                if(!isFound)
                {
                    return NotFound();
                }

                db.Update<BokT01>(book);
                return Ok();
            }
        }

        // DELETE: api/Book/5
        public IHttpActionResult Delete(int id)
        {
            using(var db = WebApiApplication.DbFactory.Open())
            {
                bool isFound = db.Exists<BokT01>(b => b.T01F01 == id);
                if (!isFound)
                {
                    return NotFound();
                }

                db.DeleteById<BokT01>(id);
                return Ok();
            }
        }
    }
}
