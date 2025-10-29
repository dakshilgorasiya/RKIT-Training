using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReadingRoom.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ReadingRoom.Api.Tests
{
    public class CustomApiFactory: WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Find and remove the DbContextOptions registration
                //var dbContextDescriptor = services.SingleOrDefault(
                //    d => d.ServiceType == typeof(DbContextOptions<AppDbContext>));

                //if (dbContextDescriptor != null)
                //{
                //    services.Remove(dbContextDescriptor);
                //}

                //var dbContextServiceDescriptor = services.SingleOrDefault(
                //    d => d.ServiceType == typeof(AppDbContext));

                //if (dbContextServiceDescriptor != null)
                //{
                //    services.Remove(dbContextServiceDescriptor);
                //}

                    //services.RemoveAll<AppDbContext>();

                //services.RemoveAll<DbContextOptions<AppDbContext>>();

                //// Add a new in-memory database context
                //services.AddDbContext<AppDbContext>(options =>
                //{
                //    options.UseInMemoryDatabase($"InMemoryDbForTesting-{System.Guid.NewGuid()}");
                //});
            });
        }
    }
}
