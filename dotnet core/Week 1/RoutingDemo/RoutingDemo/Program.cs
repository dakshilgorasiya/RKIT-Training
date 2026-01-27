
namespace RoutingDemo
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

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            //app.MapControllerRoute(
            //    name: "value",
            //    pattern: "api/value/{action}/{id:int?}",
            //    defaults: new { controller = "values" }
            //    );

            app.MapControllerRoute(
                name: "valueMultiple",
                pattern: "api/value/{action}/{*path}",
                defaults: new { controller = "values" }
                );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action}/{id?}"
                );

            app.MapControllers();

            app.Run();
        }
    }
}