
using Microsoft.AspNetCore.RateLimiting;

namespace RateLimitingDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddRateLimiter(options =>
            {
                options.AddFixedWindowLimiter("fixed", limiterOptions =>
                {
                    limiterOptions.PermitLimit = 5;
                    limiterOptions.Window = TimeSpan.FromMinutes(2);
                    limiterOptions.QueueLimit = 2;
                    limiterOptions.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
                });

                options.AddSlidingWindowLimiter("sliding", limiterOptions =>
                {
                    limiterOptions.PermitLimit = 6;
                    limiterOptions.SegmentsPerWindow = 2;
                    limiterOptions.Window = TimeSpan.FromMinutes(1);
                    limiterOptions.QueueLimit = 2;
                    limiterOptions.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
                });

                options.AddTokenBucketLimiter("tokenBucket", limiterOptions =>
                {
                    limiterOptions.TokenLimit = 10;
                    limiterOptions.AutoReplenishment = true;
                    limiterOptions.TokensPerPeriod = 5;
                    limiterOptions.ReplenishmentPeriod = TimeSpan.FromSeconds(30);
                    limiterOptions.QueueLimit = 2;
                    limiterOptions.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
                });

                options.AddConcurrencyLimiter("concurrency", limiterOptions =>
                {
                    limiterOptions.PermitLimit = 2;
                    limiterOptions.QueueLimit = 0;
                    limiterOptions.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
                });

                options.AddPolicy("fixed_per_ip", context =>
                {
                    var clientIp = context.Connection.RemoteIpAddress?.ToString() ?? "Unknown";

                    return R
                });
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRateLimiter();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}