using Microsoft.AspNetCore.Mvc;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;

namespace DataGridFinalDemoAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("allowAll", o =>
                {
                    o.AllowAnyHeader();
                    o.AllowAnyMethod();
                    o.AllowAnyOrigin();
                });
            });
            builder.Services.AddControllers()
      .AddJsonOptions(options => {
          // Keeps property names as they are in C# (e.g., "Id" instead of "id")
          //options.JsonSerializerOptions.PropertyNamingPolicy = null;
      });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                // 1. Fixes the 500 error by allowing Swagger to skip conflicts
                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                // 2. This is the "Magic Fix": Tell Swagger to treat DataSourceLoadOptions 
                // as a simple object so it doesn't crash trying to map its internals.
                options.MapType<DataSourceLoadOptions>(() => new Microsoft.OpenApi.Models.OpenApiSchema { Type = "object" });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("allowAll");
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}