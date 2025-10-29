using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReadingRoom.Data.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace ReadingRoom.Data.Data
{
    /// <summary>
    /// A utility class for seeding initial data into the database.
    /// </summary>
    public class DataSeeder
    {
        /// <summary>
        /// A method to seed initial data into the database if it is empty.
        /// </summary>
        /// <param name="app">An IApplicationBuilder instance used to access application services.</param>
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>(); // Get the AppDbContext from the service provider

                if (context != null)
                {
                    context.Database.EnsureCreated();

                    // Seed initial data if the Rooms table is empty
                    if (!context.Rooms.Any())
                    {
                        context.Rooms.AddRange(
                            new Room { Name = "The Study", Capacity = 4 },
                            new Room { Name = "The Grand Library", Capacity = 20 },
                            new Room { Name = "Quiet Corner", Capacity = 2 }
                        );

                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
