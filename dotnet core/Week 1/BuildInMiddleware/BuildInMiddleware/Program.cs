
using Microsoft.Extensions.FileProviders;

namespace BuildInMiddleware
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy", policy =>
                {
                    policy.WithOrigins("http://127.0.0.1:5509")
                    .AllowAnyHeader()
                    .AllowAnyHeader();
                });
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseCors("MyPolicy");

            app.UseExceptionHandler("/error");

            app.UseDefaultFiles(); 
            
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(builder.Environment.ContentRootPath)
            });


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();


            app.MapGet("/error", (HttpContext httpContext) =>
            {
                var exceptionHandler = httpContext.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();
                var exception = exceptionHandler?.Error;

                return Results.Problem(
                    detail: exception?.Message,
                    title: "An unexpected error occur",
                    statusCode: 500,
                    instance: httpContext.Request.Path
                    );
            });

            app.Run();
        }
    }
}