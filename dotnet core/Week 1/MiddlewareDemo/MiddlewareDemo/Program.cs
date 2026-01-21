using MiddlewareDemo.Middlewares;
using NLog.Web;

namespace MiddlewareDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Logging.ClearProviders();
            builder.Host.UseNLog();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            // Shorthand middleware
            app.Use(async (context, next) =>
            {
                Console.WriteLine($"Request: {context.Request.Path}");

                await next();

                Console.WriteLine($"Response: {context.Response.StatusCode}");
            });

            // Class middleware
            
            app.UseMiddleware<LoggingMiddleware>();
            app.UseMiddleware<NLogMiddleware>();

            // using extension methods
            // app.UseLogging();

            // For specific route
            app.UseWhen(context => context.Request.Path == "/WeatherForecast/hello", helloApp =>
            {
                helloApp.Use(async (context, next) =>
                {
                    Console.WriteLine("Hello called");
                    await next();
                });
            });


            app.MapControllers();

            app.Run();
        }
    }
}