using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using TodoListDemo.DTOs;
using TodoListDemo.Models;

namespace TodoListDemo.Controllers
{
    [RoutePrefix("api/v1/todo")]
    public class TodoController : ApiController
    {
        [Route("add")]
        [Authorize]
        [HttpPost]
        public IHttpActionResult AddTodo(TodoDTO dto)
        {
            var identity = (ClaimsIdentity)User.Identity;

            TodT01 todo = new TodT01();
            todo.T01F02 = dto.Title;
            todo.T01F03 = false;

            string userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;

            todo.T01F04 = int.Parse(userId);

            using (var db = WebApiApplication.DbFactory.OpenDbConnection())
            {
                db.Insert<TodT01>(todo);
            }

            return Ok(todo);
        }


        [Route("toggleTodo")]
        [Authorize]
        [HttpPatch]
        public IHttpActionResult toggleTodo(int id)
        {
            var identity = (ClaimsIdentity)User.Identity;
            string userIdString = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            int userId = int.Parse(userIdString);
            using (var db = WebApiApplication.DbFactory.Open())
            {
                TodT01 todo = db.Single<TodT01>(t => t.T01F01 == id && t.T01F04 == userId);

                if (todo == null)
                {
                    return NotFound();
                }

                todo.T01F03 = !todo.T01F03;

                db.Update<TodT01>(todo);

                return Ok();
            }
        }

        [Route("removeTodo")]
        [HttpDelete]
        [Authorize]
        public IHttpActionResult removeTodo(int id)
        {
            var identity = (ClaimsIdentity)User.Identity;
            string userIdString = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            int userId = int.Parse(userIdString);
            using (var db = WebApiApplication.DbFactory.Open())
            {
                bool isExists = db.Exists<TodT01>(t => t.T01F01 == id);

                if (!isExists)
                {
                    return NotFound();
                }

                db.DeleteById<TodT01>(id);

                return Ok();
            }
        }


        [Route("updateTodo")]
        [HttpPut]
        [Authorize]
        public IHttpActionResult updateTodo(int id, TodoDTO todoDTO)
        {
            var identity = (ClaimsIdentity)User.Identity;
            string userIdString = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            int userId = int.Parse(userIdString);
            using (var db = WebApiApplication.DbFactory.Open())
            {
                TodT01 todo = db.Single<TodT01>(t => t.T01F01 == id && t.T01F04 == userId);

                if(todo == null)
                {
                    return NotFound();
                }

                todo.T01F02 = todoDTO.Title;

                db.Update<TodT01>(todo);

                return Ok();
            }
        }

        [HttpGet]
        [Route("GetTodos")]
        [Authorize]
        public IHttpActionResult getTodos()
        {
            var identity = (ClaimsIdentity)User.Identity;
            string userIdString = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            int userId = int.Parse(userIdString);
            using (var db = WebApiApplication.DbFactory.Open())
            {
                IEnumerable<TodT01> todos = db.Select<TodT01>(t => t.T01F04 == userId);
                return Ok(todos);
            }
        }
    }
}
