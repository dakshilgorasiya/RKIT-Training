using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReadingRoom.Data.Model;

namespace ReadingRoom.Data.Data
{
    /// <summary>
    /// A DbContext for the application, managing Room and Reservation entities.
    /// </summary>
    public class AppDbContext: DbContext
    {
        /// <summary>
        /// A DbSet representing the collection of Room entities in the database.
        /// </summary>
        public DbSet<Room> Rooms { get; set; }

        /// <summary>
        /// A DbSet representing the collection of Reservation entities in the database.
        /// </summary>
        public DbSet<Reservation> Reservations { get; set; }

        /// <summary>
        /// A constructor that accepts DbContextOptions and passes them to the base DbContext class.
        /// </summary>
        /// <param name="options">A DbContextOptions object containing configuration information.</param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// A method to configure the model relationships and constraints.
        /// </summary>
        /// <param name="modelBuilder">A ModelBuilder object used to configure the model.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Set up the one-to-many relationship between Room and Reservation
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Room)
                .WithMany(r => r.Reservations)
                .HasForeignKey(r => r.RoomId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
