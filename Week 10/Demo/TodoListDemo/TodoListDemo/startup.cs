using Microsoft.Owin;
using Owin;
using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Web.Http;


[assembly: OwinStartup(typeof(TodoListDemo.Startup))]

namespace TodoListDemo
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            var issuer = ConfigurationManager.AppSettings["jwtIssuer"];
            var audience = ConfigurationManager.AppSettings["jwtAudience"];
            var secret = Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["jwtSecret"]);

            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                AuthenticationMode = AuthenticationMode.Active,
                TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(secret)
                },
            });

            app.UseWebApi(config);
        }
    }
}
