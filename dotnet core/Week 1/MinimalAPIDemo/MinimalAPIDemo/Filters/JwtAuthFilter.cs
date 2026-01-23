using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace MinimalAPIDemo.Filters
{
    public class JwtAuthFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var http = context.HttpContext;

            if (!http.Request.Headers.TryGetValue("Authorization", out var authHeader))
            {
                return Results.Unauthorized();
            }

            var headerValue = authHeader.ToString();

            if (!headerValue.StartsWith("Bearer "))
            {
                return Results.Unauthorized();
            }

            var token = headerValue["Bearer ".Length..].Trim();

            var tokenHandler = new JwtSecurityTokenHandler();
            var keyBytes = Encoding.UTF8.GetBytes("VtV2wlXcVuSpI3UIJ0IDJz8U6ipkZkeIZmAYcxqV3E33XLqzsgwSyQMvHOKi8Ri2");

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
                }, out _);

                return await next(context);
            }
            catch
            {
                return Results.Unauthorized();
            }
        }
    }
}
