using Owin;
using Microsoft.Owin;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security.Jwt;
using System.Configuration;
using System.Text;
using Microsoft.Owin.Security;

[assembly: OwinStartup(typeof(FiltersDemo.Startup))] // Replace with your actual namespace

namespace FiltersDemo
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            var issuer = ConfigurationManager.AppSettings["jwtIssuer"];
            var audience = ConfigurationManager.AppSettings["jwtAudience"];
            var secret = Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["jwtSecret"]);

            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                AuthenticationMode = AuthenticationMode.Active,
                TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(secret)
                },
            });

        }
    }
}
