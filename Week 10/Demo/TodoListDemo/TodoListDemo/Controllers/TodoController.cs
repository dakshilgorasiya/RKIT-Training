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
using StackExchange.Redis;
using NLog;

namespace TodoListDemo.Controllers
{
    /// <summary>
    /// A controller to handle todo related tasks
    /// </summary>
    [RoutePrefix("api/v1/todo")]
    public class TodoController : ApiController
    {
        // Logger to log information
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        // Redis connection instance
        private readonly IDatabase _redis;

        public TodoController()
        {
            _redis = RedisConnection.Connection.GetDatabase();
        }

        /// <summary>
        /// A method to add todo
        /// </summary>
        /// <param name="dto">Todo information</param>
        /// <returns>201 created</returns>
        [Route("add")]
        [Authorize]
        [HttpPost]
        public IHttpActionResult AddTodo(TodoDTO dto)
        {
            // get userid from token
            var identity = (ClaimsIdentity)User.Identity;
            string userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;

            Logger.Info($"User {userId} creating new todo: {dto.Title}");

            // map DTO to POCO
            TodT01 todo = new TodT01();
            todo.T01F02 = dto.Title;
            todo.T01F03 = false;
            todo.T01F04 = int.Parse(userId);

            // Insert POCO to db
            long id;
            using (var db = WebApiApplication.DbFactory.OpenDbConnection())
            {
                id = db.Insert<TodT01>(todo, selectIdentity: true);
            }

            // Delete cache entries
            string cachekey = $"todos:${userId}";
            _redis.KeyDelete(cachekey);

            Logger.Info($"Todo created successfully with ID: {id} for user {userId}");

            // Convert POCO to DTO to hide sensitive infomation
            TodoResponseDTO response = new TodoResponseDTO
            {
                TodoId = (int)id,
                Title = todo.T01F02,
                IsCompleted = false,
            };

            return Ok(response);
        }


        /// <summary>
        /// Method to mark todo as done and undone
        /// </summary>
        /// <param name="id">Id of todo</param>
        /// <returns>404 if todo does not exists, 200 otherwise</returns>
        [Route("toggleTodo")]
        [Authorize]
        [HttpPatch]
        public IHttpActionResult toggleTodo(int id)
        {
            // get userid from token
            var identity = (ClaimsIdentity)User.Identity;
            string userIdString = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            int userId = int.Parse(userIdString);

            Logger.Info($"User {userId} toggling todo {id}");

            // create database connection
            using (var db = WebApiApplication.DbFactory.Open())
            {
                TodT01 todo = db.Single<TodT01>(t => t.T01F01 == id && t.T01F04 == userId);

                if (todo == null)
                {
                    Logger.Warn($"Todo {id} not found for user {userId}");
                    return NotFound();
                }

                // Toggle todo
                todo.T01F03 = !todo.T01F03;

                // Update db
                db.Update<TodT01>(todo);

                // Remove cache entries
                string cachekey = $"todos:${userId}";
                _redis.KeyDelete(cachekey);

                string todoCacheKey = $"todo:${id}:${userId}";
                _redis.KeyDelete(todoCacheKey);

                Logger.Info($"Todo {id} toggled successfully for user {userId}. New status: {todo.T01F03}");

                return Ok();
            }
        }

        /// <summary>
        /// A method to remove todo
        /// </summary>
        /// <param name="id">Id of todo to remove</param>
        /// <returns>404 if not found, 200 otherwise</returns>
        [Route("removeTodo")]
        [HttpDelete]
        [Authorize]
        public IHttpActionResult removeTodo(int id)
        {
            // Get user id from token
            var identity = (ClaimsIdentity)User.Identity;
            string userIdString = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            int userId = int.Parse(userIdString);

            Logger.Info($"User {userId} removing todo {id}");

            // Create database connection
            using (var db = WebApiApplication.DbFactory.Open())
            {
                // Check if todo exists
                bool isExists = db.Exists<TodT01>(t => t.T01F01 == id);
                if (!isExists)
                {
                    Logger.Warn($"Todo {id} not found for removal by user {userId}");
                    return NotFound();
                }

                // Delete todo
                db.DeleteById<TodT01>(id);

                // Remove cache entries
                string cachekey = $"todos:${userId}";
                _redis.KeyDelete(cachekey);

                string todoCacheKey = $"todo:${id}:${userId}";
                _redis.KeyDelete(todoCacheKey);

                Logger.Info($"Todo {id} removed successfully by user {userId}");

                return Ok();
            }
        }


        /// <summary>
        /// A method to update todo
        /// </summary>
        /// <param name="id">Id of todo</param>
        /// <param name="todoDTO">Todo information</param>
        /// <returns>404 if not found, 200 otherwise</returns>
        [Route("updateTodo")]
        [HttpPut]
        [Authorize]
        public IHttpActionResult updateTodo(int id, TodoDTO todoDTO)
        {
            // Get userif from token
            var identity = (ClaimsIdentity)User.Identity;
            string userIdString = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            int userId = int.Parse(userIdString);

            Logger.Info($"User {userId} updating todo {id} with title: {todoDTO.Title}");

            // Create db connection
            using (var db = WebApiApplication.DbFactory.Open())
            {
                TodT01 todo = db.Single<TodT01>(t => t.T01F01 == id && t.T01F04 == userId);

                // if todo not exists
                if (todo == null)
                {
                    Logger.Warn($"Todo {id} not found for update by user {userId}");
                    return NotFound();
                }

                // update todo
                todo.T01F02 = todoDTO.Title;

                // update db
                db.Update<TodT01>(todo);

                // remove cache entries
                string cachekey = $"todos:${userId}";
                _redis.KeyDelete(cachekey);

                string todoCacheKey = $"todo:${id}:${userId}";
                _redis.KeyDelete(todoCacheKey);

                Logger.Info($"Todo {id} updated successfully by user {userId}");

                return Ok();
            }
        }

        /// <summary>
        /// A method to get all todos of user
        /// </summary>
        /// <returns>Todos</returns>
        [HttpGet]
        [Route("GetTodos")]
        [Authorize]
        public IHttpActionResult getTodos()
        {
            // Get user if from token
            var identity = (ClaimsIdentity)User.Identity;
            string userIdString = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            int userId = int.Parse(userIdString);

            // Check if it exists in cache
            string cacheKey = $"todos:${userId}";
            var cachedData = _redis.StringGet(cacheKey);
            if (!cachedData.IsNull)
            {
                Logger.Info($"Cache hit for ${cacheKey}");
                List<TodoResponseDTO> todos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TodoResponseDTO>>(cachedData);
                return Ok(todos);
            }

            Logger.Info($"Cache miss for ${cacheKey}");

            // Create db connection
            using (var db = WebApiApplication.DbFactory.Open())
            {
                // Fetch todos
                IEnumerable<TodT01> todos = db.Select<TodT01>(t => t.T01F04 == userId);

                // Map todos to reposnse DTO to hide sensitive info
                List<TodoResponseDTO> response = new List<TodoResponseDTO>();
                foreach (TodT01 todo in todos)
                {
                    TodoResponseDTO temp = new TodoResponseDTO
                    {
                        TodoId = todo.T01F01,
                        Title = todo.T01F02,
                        IsCompleted = todo.T01F03,
                    };
                    response.Add(temp);
                }

                // Store response in cache
                _redis.StringSet(
                    cacheKey,
                    Newtonsoft.Json.JsonConvert.SerializeObject(response),
                    TimeSpan.FromMinutes(10)
                    );

                return Ok(response);
            }
        }

        /// <summary>
        /// To get todo by Id
        /// </summary>
        /// <param name="id">id of todo</param>
        /// <returns>404 if todo not exits, 200 otherwise</returns>
        [HttpGet]
        [Route("GetTodo/{id}")]
        [Authorize]
        public IHttpActionResult GetTodoById(int id)
        {
            // Get user id from token
            var identity = (ClaimsIdentity)User.Identity;
            string userIdString = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            int userId = int.Parse(userIdString);

            // Check if reposne if cached
            string cacheKey = $"todo:${id}:${userId}";
            var cachedData = _redis.StringGet(cacheKey);
            if (!cachedData.IsNull)
            {
                Logger.Info($"Cache hit for {cacheKey}");
                TodoResponseDTO todos = Newtonsoft.Json.JsonConvert.DeserializeObject<TodoResponseDTO>(cachedData);
                return Ok(todos);
            }

            Logger.Info($"Cache miss for {cacheKey}");

            // Open db connection
            using (var db = WebApiApplication.DbFactory.Open())
            {
                // Fetch todo
                TodT01 todo = db.Single<TodT01>(t => t.T01F01 == id && t.T01F04 == userId);

                // Check if todo exists
                if (todo == null)
                {
                    return NotFound();
                }

                // convert POCO to responce DTO to hide sensitive info
                TodoResponseDTO response = new TodoResponseDTO()
                {
                    TodoId = id,
                    Title = todo.T01F02,
                    IsCompleted = todo.T01F03
                };

                // Store response in cache
                _redis.StringSet(
                   cacheKey,
                   Newtonsoft.Json.JsonConvert.SerializeObject(response),
                   TimeSpan.FromMinutes(10)
                   );

                return Ok(todo);
            }
        }
    }
}
