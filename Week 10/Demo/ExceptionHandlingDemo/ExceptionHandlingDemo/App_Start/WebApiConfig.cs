using ExceptionHandlingDemo.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using ExceptionHandlingDemo.Handlers;

namespace ExceptionHandlingDemo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Handle exceptions globally using a custom exception handler
            config.Services.Replace(
                    typeof(IExceptionHandler),
                    new GlobalExceptionHandler()
                );

            // Alternatively, we can use an exception filter
            // To enable globally
            // config.Filters.Add(new GlobalExceptionFilter());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
