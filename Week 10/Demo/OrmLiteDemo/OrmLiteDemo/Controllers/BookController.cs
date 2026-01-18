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
    /// <summary>
    /// A simple Web API controller for managing books using ServiceStack.OrmLite.
    /// </summary>
    public class BookController : ApiController
    {
        /// <summary>
        /// A GET method to retrieve all books from the database.
        /// </summary>
        /// <returns></returns>
        // GET: api/Book
        public IHttpActionResult Get()
        {
            // Create a database connection using the DbFactory from WebApiApplication
            using (var db = WebApiApplication.DbFactory.Open())
            {
                // Retrieve all books from the BokT01 table
                IEnumerable<BokT01> books = db.Select<BokT01>();
                return Ok(books);
            }
        }

        /// <summary>
        /// A GET method to retrieve a specific book by its ID.
        /// </summary>
        /// <param name="id">id of book</param>
        /// <returns>404 if not found, 200 else</returns>
        // GET: api/Book/5
        public IHttpActionResult Get(int id)
        {
            // Create a database connection using the DbFactory from WebApiApplication
            using (var db = WebApiApplication.DbFactory.Open())
            {
                // Retrieve the book with the specified ID from the BokT01 table
                BokT01 book = db.SingleById<BokT01>(id);

                // check if the book was found
                if (book == null)
                {
                    return NotFound();
                }
                return Ok(book);
            }
        }

        /// <summary>
        /// A POST method to add a new book to the database.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        // POST: api/Book
        public IHttpActionResult Post([FromBody]BokT01 book)
        {
            // Create a database connection using the DbFactory from WebApiApplication
            using (var db = WebApiApplication.DbFactory.OpenDbConnection())
            {
                // Insert the new book into the BokT01 table
                db.Insert<BokT01>(book);
                return Created<BokT01>("", book);
            }
        }

        /// <summary>
        /// A PUT method to update an existing book in the database.
        /// </summary>
        /// <param name="book">Book details</param>
        /// <returns>404 if not found, 200 otherwise</returns>
        // PUT: api/Book/5
        public IHttpActionResult Put([FromBody]BokT01 book)
        {
            // Create a database connection using the DbFactory from WebApiApplication
            using (var db = WebApiApplication.DbFactory.Open())
            {
                // Check if the book exists in the BokT01 table
                bool isFound = db.Exists<BokT01>(b => b.T01F01 == book.T01F01);
                if(!isFound)
                {
                    return NotFound();
                }

                // Update the book details in the BokT01 table
                db.Update<BokT01>(book);
                return Ok();
            }
        }

        /// <summary>
        /// A DELETE method to remove a book from the database by its ID.
        /// </summary>
        /// <param name="id">id of book</param>
        /// <returns>404 if not found, 200 else</returns>
        // DELETE: api/Book/5
        public IHttpActionResult Delete(int id)
        {
            // Create a database connection using the DbFactory from WebApiApplication
            using (var db = WebApiApplication.DbFactory.Open())
            {
                // Check if the book exists in the BokT01 table
                bool isFound = db.Exists<BokT01>(b => b.T01F01 == id);
                if (!isFound)
                {
                    return NotFound();
                }

                // Delete the book with the specified ID from the BokT01 table
                db.DeleteById<BokT01>(id);
                return Ok();
            }
        }
    }
}
