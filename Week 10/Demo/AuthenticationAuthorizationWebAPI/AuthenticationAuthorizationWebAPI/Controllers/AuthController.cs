using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using AuthenticationAuthorizationWebAPI.Models;
using System.Configuration;

namespace AuthenticationAuthorizationWebAPI.Controllers
{
    /// <summary>
    /// This controller handles authentication
    /// </summary>
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        /// <summary>
        /// Action method to login and get JWT token
        /// </summary>
        /// <param name="model">DTO of LoginRequest type</param>
        /// <returns>200 if valid user else 401</returns>
        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login(LoginRequest model)
        {
            if (model.Username == "admin" && model.Password == "password")
            {
                return Ok(new { token = CreateJwtToken(model.Username, "Admin") });
            }
            return Unauthorized();
        }

        private string CreateJwtToken(string username, string role)
        {
            var secret = ConfigurationManager.AppSettings["jwtSecret"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role),
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
    }
}
