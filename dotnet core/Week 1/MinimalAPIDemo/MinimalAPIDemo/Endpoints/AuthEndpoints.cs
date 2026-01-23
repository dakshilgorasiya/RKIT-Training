using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MinimalAPIDemo.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MinimalAPIDemo.Endpoints
{
    public class AuthEndpoints
    {
        public static IResult login([FromBody]LoginDTO loginDTO)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, loginDTO.UserName),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes("VtV2wlXcVuSpI3UIJ0IDJz8U6ipkZkeIZmAYcxqV3E33XLqzsgwSyQMvHOKi8Ri2")),
                        SecurityAlgorithms.HmacSha256
                    )
                );

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return Results.Ok(new { token = jwtToken });
        }
    }
}
