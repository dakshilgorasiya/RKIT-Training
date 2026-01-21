using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.Results;
using Microsoft.IdentityModel.Tokens;

public class JwtAuthenticationFilter : Attribute, IAuthenticationFilter
{
    public bool AllowMultiple => false;

    public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
    {
        var authHeader = context.Request.Headers.Authorization;

        if (authHeader == null || authHeader.Scheme != "Bearer")
        {
            context.ErrorResult = new UnauthorizedResult(
                new System.Net.Http.Headers.AuthenticationHeaderValue[0],
                context.Request);
            return;
        }

        var token = authHeader.Parameter;

        var principal = ValidateToken(token);

        if (principal == null)
        {
            context.ErrorResult = new UnauthorizedResult(
                new System.Net.Http.Headers.AuthenticationHeaderValue[0],
                context.Request);
            return;
        }   

        context.Principal = principal;
    }

    public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
    {
        // Only add challenge if response is 401
        if (context.Result is UnauthorizedResult)
        {
            context.Result = new UnauthorizedResult(
                new[] { new AuthenticationHeaderValue("Bearer") },
                context.Request);
        }

        return Task.CompletedTask;
    }

    private ClaimsPrincipal ValidateToken(string token)
    {
        try
        {
            var key = Encoding.UTF8.GetBytes(
                System.Configuration.ConfigurationManager.AppSettings["jwtSecret"]);

            var tokenHandler = new JwtSecurityTokenHandler();

            var parameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = System.Configuration.ConfigurationManager.AppSettings["jwtIssuer"],
                ValidAudience = System.Configuration.ConfigurationManager.AppSettings["jwtAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(key),
            };

            SecurityToken validatedToken;
            var principal = tokenHandler.ValidateToken(token, parameters, out validatedToken);

            return principal;
        }
        catch
        {
            return null;
        }
    }
}
