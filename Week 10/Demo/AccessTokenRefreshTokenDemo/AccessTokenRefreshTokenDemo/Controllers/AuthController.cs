using AccessTokenRefreshTokenDemo.DTOs;
using AccessTokenRefreshTokenDemo.Models;
using AccessTokenRefreshTokenDemo.Services;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AccessTokenRefreshTokenDemo.Controllers
{
    [RoutePrefix("api/v1/auth")]
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("register")]
        public IHttpActionResult Register(UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Username and password is required");
            }

            DbUser user = new DbUser();

            user.Name = userDTO.Name;

            user.PasswordHash = PasswordService.HashPassword(userDTO.Password);

            using (var db = WebApiApplication.DbFactory.Open())
            {
                db.Insert<DbUser>(user);
            }

            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login(UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Username and password is required");
            }

            using (var db = WebApiApplication.DbFactory.Open())
            {
                var user = db.Single<DbUser>(u => u.Name == userDTO.Name);

                if (user == null)
                {
                    return NotFound();
                }

                if (user.PasswordHash != PasswordService.HashPassword(userDTO.Password))
                {
                    return Unauthorized();
                }

                var accessToken = TokenService.GenerateAccessToken(user.Id, user.Name);
                var refreshToken = TokenService.GenerateRefreshToken(user.Id, user.Name);

                RefreshToken refreshTokenObject = new RefreshToken();

                refreshTokenObject.UserId = user.Id;
                refreshTokenObject.Token = refreshToken;
                refreshTokenObject.ExpiresAt = DateTime.UtcNow.AddDays(Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["RefreshTokenExpiryDays"]));
                refreshTokenObject.CreatedAt = DateTime.UtcNow;
                refreshTokenObject.IsRevoked = false;

                db.Delete<RefreshToken>(r => r.UserId == user.Id);

                db.Insert<RefreshToken>(refreshTokenObject);

                return Ok(new { accessToken, refreshToken });
            }

        }

        [HttpPost]
        [Route("refresh")]
        public async Task<IHttpActionResult> Refresh([FromBody]string refreshToken)
        {
            System.Diagnostics.Debug.WriteLine($"refreshToken: {refreshToken}");
            using (var db = WebApiApplication.DbFactory.Open())
            {
                var tokenEntry = db.Single<RefreshToken>(r => r.Token == refreshToken && r.IsRevoked == false);

                if (tokenEntry == null || tokenEntry.ExpiresAt < DateTime.UtcNow)
                {
                    return Unauthorized();
                }

                var user = db.SingleById<DbUser>(tokenEntry.UserId);

                var accessToken = TokenService.GenerateAccessToken(user.Id, user.Name);
                var newRefreshToken = TokenService.GenerateRefreshToken(user.Id, user.Name);

                RefreshToken refreshTokenEntry = new RefreshToken();
                refreshTokenEntry.UserId = user.Id;
                refreshTokenEntry.Token = newRefreshToken;
                refreshTokenEntry.ExpiresAt = DateTime.UtcNow.AddDays(Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["RefreshTokenExpiryDays"]));
                refreshTokenEntry.CreatedAt = DateTime.UtcNow;
                refreshTokenEntry.IsRevoked = false;

                await db.DeleteAsync<RefreshToken>(r => r.UserId == user.Id);

                await db.InsertAsync<RefreshToken>(refreshTokenEntry);


                return Ok(new { accessToken, newRefreshToken });
            }
        }
    }
}
