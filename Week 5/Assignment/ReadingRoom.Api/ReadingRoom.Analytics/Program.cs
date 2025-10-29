using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ReadingRoom.Data.Data;
using ReadingRoom.Data.Model;
using System.Threading.Tasks;
using System.Data;

namespace ReadingRoom.Analytics
{    
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Create a host to manage application services
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, service) =>
                {
                    var connectionString = context.Configuration.GetConnectionString("DefaultConnection");

                    service.AddDbContext<AppDbContext>(options =>
                        options.UseSqlite(connectionString, b => b.MigrationsAssembly("ReadingRoom.Data")));
                })
                .Build();

            using var scope = host.Services.CreateScope();

            // Get the AppDbContext
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            Console.WriteLine("\n\n\nLINQ in List");
            await ListQuery.Query(dbContext);

            Console.WriteLine("\n\n\nLINQ in DataTable");
            await DataTableQuery.Query(dbContext);


            Console.WriteLine("\n\n\nDynamic Demo");
            await DynamicDemo.PerformDemo();
        }
    }
}
