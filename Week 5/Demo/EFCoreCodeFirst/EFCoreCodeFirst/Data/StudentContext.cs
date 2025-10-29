using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EFCoreCodeFirst.Models;

namespace EFCoreCodeFirst.Data
{
    public class StudentContext: DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;user=root;password=Dakshil@123;database=student", ServerVersion.AutoDetect("Server=localhost;user=root;password=Dakshil@123;database=employee"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Courses)
                .WithMany(c => c.Students)
                .UsingEntity(j => j.ToTable("StudentCourses"));

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Department)
                .WithMany(d => d.Students)
                .HasForeignKey(s => s.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
