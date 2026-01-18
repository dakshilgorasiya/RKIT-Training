using Microsoft.Owin;
using Owin;
using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;

[assembly: OwinStartup(typeof(TodoListDemo.Startup))]

namespace TodoListDemo
{
    /// <summary>
    /// A class to configure OWIN middleware
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// A method to configure the OWIN pipeline
        /// </summary>
        /// <param name="app">The app builder</param>
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            // Configuration for JWT Authentication
            var issuer = ConfigurationManager.AppSettings["jwtIssuer"];
            var audience = ConfigurationManager.AppSettings["jwtAudience"];
            var secret = Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["jwtSecret"]);

            // Enable JWT Bearer Authentication
            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                // Set the authentication mode to active
                AuthenticationMode = AuthenticationMode.Active,

                // Set the token validation parameters
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