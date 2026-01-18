using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Web.Http;
using TodoListDemo.DTOs;
using TodoListDemo.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Owin;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using ServiceStack.OrmLite;
using NLog;

namespace TodoListDemo.Controllers
{
    /// <summary>
    /// A controller for handling authentication related tasks
    /// </summary>
    [RoutePrefix("api/v1/auth")]
    public class AuthController : ApiController
    {
        // Logger to log information
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();


        /// <summary>
        /// To create user
        /// </summary>
        /// <param name="dto">User details</param>
        /// <returns>400 If user exists else 200</returns>
        [Route("register")]
        [HttpPost]
        public IHttpActionResult RegisterUser(UserDTO dto)
        {
            Logger.Info($"Registration attempt for user: {dto.UserName}");

            // Map DTO to POCO
            TodT02 user = new TodT02();
            user.T02F02 = dto.UserName;
            user.T02F03 = HashPassword(dto.Password);

            // Create db connection
            using (var db = WebApiApplication.DbFactory.OpenDbConnection())
            {
                // Check if user already exists
                bool isUserExists = db.Exists<TodT02>(u => u.T02F02 == dto.UserName);
                if(isUserExists)
                {
                    Logger.Warn($"Registration failed: User {dto.UserName} already exists");
                    return BadRequest("User already exists");
                }

                // Create a new user
                db.Insert<TodT02>(user);
                Logger.Info($"User registered successfully: {dto.UserName}");
            }

            return Ok(user);
        }

        /// <summary>
        /// A method to get JWT token for authorization
        /// </summary>
        /// <param name="dto">User information</param>
        /// <returns>400 if user is not found, 401 is password is wrong, 200 and token if valid</returns>
        [Route("login")]
        [HttpPost]
        public IHttpActionResult LoginUser(UserDTO dto)
        {
            Logger.Info($"Login attempt for user: {dto.UserName}");

            // Create database connection
            using(var db = WebApiApplication.DbFactory.Open())
            {
                // get user
                TodT02 user = db.Single<TodT02>(u => u.T02F02 == dto.UserName);

                // If user does not exists
                if(user == null)
                {
                    Logger.Warn($"Login failed: User {dto.UserName} not found");
                    return NotFound();
                }

                // Create hash of password
                string passwordHash = HashPassword(dto.Password);

                // Compare hash with stored hash
                if(passwordHash != user.T02F03)
                {
                    Logger.Warn($"Login failed: Invalid password for user {dto.UserName}");
                    return Unauthorized();
                }

                Logger.Info($"User logged in successfully: {dto.UserName}");
                // return generated token
                return Ok(new { token = CreateJwtToken(user.T02F01, dto.UserName) });
            }
        }

        /// <summary>
        /// A method to create jwt token for user
        /// </summary>
        /// <param name="id">Id of user</param>
        /// <param name="username">name of user</param>
        /// <returns>Jwt token</returns>
        private string CreateJwtToken(int id, string username)
        {
            // Secret key
            var secret = ConfigurationManager.AppSettings["jwtSecret"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Claim to add in token
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.NameIdentifier, id.ToString())
            };

            // create token
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: ConfigurationManager.AppSettings["jwtIssuer"],
                audience: ConfigurationManager.AppSettings["jwtAudience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
                );

            // Convert token to string and return
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// A method to create hash of password
        /// </summary>
        /// <param name="password">Raw password</param>
        /// <returns>Hash of password</returns>
        public static string HashPassword(string password)
        {
            // Create SHA256 instance to create hash
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
