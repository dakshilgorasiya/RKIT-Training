using Microsoft.EntityFrameworkCore;
using ReadingRoom.Data.Data;
using ReadingRoom.Api.Endpoints;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

namespace ReadingRoom.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create a builder for the web application
            var builder = WebApplication.CreateBuilder(args);

            // Configure the database connection
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(option =>
                option.UseSqlite(connectionString, b => b.MigrationsAssembly("ReadingRoom.Data")));

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddRateLimiter(options =>
            {
                options.AddFixedWindowLimiter("Fixed", config =>
                {
                    config.PermitLimit = 10;
                    config.Window = TimeSpan.FromSeconds(30);
                    config.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                    config.QueueLimit = 0;
                });
            });

            // Build the application
            var app = builder.Build();

            // Seed initial data
            if(!app.Environment.IsEnvironment("Testing"))
            {
                DataSeeder.Seed(app);
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // Map endpoints for room management and apply rate limiting
            var roomGroup = app.MapGroup("/rooms").RequireRateLimiting("Fixed");

            roomGroup.MapGet("/", RoomEndpoints.GetAllRoomsAsync);
            roomGroup.MapPost("/", RoomEndpoints.CreateRoomAsync);
            roomGroup.MapPut("/", RoomEndpoints.UpdateRoomAsync);
            roomGroup.MapDelete("/{id}", RoomEndpoints.DeleteRoomAsync);

            // Map endpoints for reservation management and apply rate limiting
            var reservationGroup = app.MapGroup("/reservations").RequireRateLimiting("Fixed");

            reservationGroup.MapPost("/", ReservationEndpoints.CreateReservationAsync);
            reservationGroup.MapGet("/", ReservationEndpoints.GetReservationsAsync);
            reservationGroup.MapPut("/", ReservationEndpoints.UpdateReservationAsync);
            reservationGroup.MapDelete("/{reservationId}", ReservationEndpoints.DeleteReservationAsync);

            app.Run();
        }
    }
}
