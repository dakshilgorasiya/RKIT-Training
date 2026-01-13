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

namespace TodoListDemo.Controllers
{
    [RoutePrefix("api/v1/auth")]
    public class AuthController : ApiController
    {
        [Route("register")]
        [HttpPost]
        public IHttpActionResult RegisterUser(UserDTO dto)
        {
            TodT02 user = new TodT02();
            user.T02F02 = dto.UserName;
            user.T02F03 = HashPassword(dto.Password);

            using (var db = WebApiApplication.DbFactory.OpenDbConnection())
            {
                bool isUserExists = db.Exists<TodT02>(u => u.T02F02 == dto.UserName);

                if(isUserExists)
                {
                    return BadRequest("User already exists");
                }

                db.Insert<TodT02>(user);
            }

            return Ok(user);
        }

        [Route("login")]
        [HttpPost]
        public IHttpActionResult LoginUser(UserDTO dto)
        {
            using(var db = WebApiApplication.DbFactory.Open())
            {
                TodT02 user = db.Single<TodT02>(u => u.T02F02 == dto.UserName);

                if(user == null)
                {
                    return NotFound();
                }

                string passwordHash = HashPassword(dto.Password);

                if(passwordHash != user.T02F03)
                {
                    return Unauthorized();
                }

                return Ok(new { token = CreateJwtToken(user.T02F01, dto.UserName) });
            }
        }

        private string CreateJwtToken(int id, string username)
        {
            var secret = ConfigurationManager.AppSettings["jwtSecret"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
            };

            var token = new JwtSecurityToken(
                issuer: ConfigurationManager.AppSettings["jwtIssuer"],
                audience: ConfigurationManager.AppSettings["jwtAudience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
