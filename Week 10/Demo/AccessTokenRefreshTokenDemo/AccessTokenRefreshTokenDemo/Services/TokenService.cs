using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

public class TokenService
{
    public static string GenerateAccessToken(int userId, string username)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(System.Configuration.ConfigurationManager.AppSettings["JwtSecret"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            new Claim(ClaimTypes.Name, username)
        };

        var token = new JwtSecurityToken(
            issuer: System.Configuration.ConfigurationManager.AppSettings["JwtIssuer"],
            audience: System.Configuration.ConfigurationManager.AppSettings["JwtAudience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["AccessTokenExpiryMinutes"])),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public static string GenerateRefreshToken(int userId, string username)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(System.Configuration.ConfigurationManager.AppSettings["JwtSecret"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            new Claim(ClaimTypes.Name, username)
        };

        var token = new JwtSecurityToken(
            issuer: System.Configuration.ConfigurationManager.AppSettings["JwtIssuer"],
            audience: System.Configuration.ConfigurationManager.AppSettings["JwtAudience"],
            claims: claims,
            expires: DateTime.UtcNow.AddDays(Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["RefreshTokenExpiryDays"])),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
