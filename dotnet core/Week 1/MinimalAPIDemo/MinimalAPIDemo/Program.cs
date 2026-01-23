using Microsoft.AspNetCore.Mvc;
using MinimalAPIDemo.Repository;
using MinimalAPIDemo.Endpoints;
using MinimalAPIDemo.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MinimalAPIDemo.Filters;

namespace MinimalAPIDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                // Add JWT Bearer auth definition
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter JWT token like: Bearer {your_token}"
                });

                // Apply JWT auth globally to all endpoints
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("VtV2wlXcVuSpI3UIJ0IDJz8U6ipkZkeIZmAYcxqV3E33XLqzsgwSyQMvHOKi8Ri2"))
                };
            });

            builder.Services.AddAuthorization();

            builder.Services.AddSingleton<IBookRepository, BookRepository>();

            var app = builder.Build();

            app.UseExceptionHandler("/error");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

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

            app.MapGet("/hello", () =>
            {
                throw new Exception("Exception raised");
            });

            app.MapPost("/createBook", BookEndpoints.CreateBook).AddEndpointFilter<GlobalValidationFilter>();
            app.MapGet("/getAllBooks", BookEndpoints.GetAllBooks).RequireAuthorization();
            app.MapDelete("/deleteBook/{id}", BookEndpoints.DeleteBook);
            app.MapGet("/getBookById/{id}", BookEndpoints.GetBookById).AddEndpointFilter(new JwtAuthFilter());
            app.MapPatch("/updateBook/{id}", BookEndpoints.UpdateBook).AddEndpointFilter<GlobalValidationFilter>();

            app.MapPost("/login", AuthEndpoints.login);

            app.MapGet("/validationerror", () =>
            {
                var errors = new Dictionary<string, string[]>
                {
                    { "Name", new[] { "Name is required." } },
                    { "Age", new[] { "Age must be > 0." } }
                };

                return Results.ValidationProblem(errors);
            });

            app.Run();
        }
    }
}