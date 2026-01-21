using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Web.Http;

namespace FiltersDemo.Controllers
{
    [RoutePrefix("api/v1/auth")]
    public class AuthController : ApiController
    {
        [HttpGet]
        [Route("getToken")]
        public IHttpActionResult GetToken()
        {
            return Ok(CreateJwtToken("abc", "admin"));
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
