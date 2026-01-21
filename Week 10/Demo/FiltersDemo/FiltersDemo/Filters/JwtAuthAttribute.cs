using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace FiltersDemo.Filters
{
    public class JwtAuthAttribute: AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var headers = actionContext.Request.Headers;

            if (headers.Authorization == null || headers.Authorization.Scheme != "Bearer")
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "Missing token");
                return;
            }

            var token = headers.Authorization.Parameter;

            try
            {
                var secretKey = Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["jwtSecret"]);

                var tokenHandler = new JwtSecurityTokenHandler();

                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = ConfigurationManager.AppSettings["jwtIssuer"],
                    ValidateAudience = true,
                    ValidAudience = ConfigurationManager.AppSettings["jwtAudience"],
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                    ValidateIssuerSigningKey = true
                };

                SecurityToken validatedToken;
                var principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);

                Thread.CurrentPrincipal = principal;

                if(HttpContext.Current != null)
                {
                    HttpContext.Current.User = principal;
                }
            }
            catch(Exception)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "Invalide token");
            }
        }
    }
}