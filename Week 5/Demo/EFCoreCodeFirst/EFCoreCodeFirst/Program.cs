using EFCoreCodeFirst.Models;
using EFCoreCodeFirst.Data;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCodeFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentContext context = new StudentContext();

            Department computerDepartment = new Department
            {
                Id = 1,
                Name = "Computer Science",
                Location = "Building A"
            };

            //context.Departments.Add(computerDepartment);
            //context.SaveChanges();

            Student student1 = new Student
            {
                Name = "Alice",
                DepartmentId = computerDepartment.Id
            };

            Student student2 = new Student
            {
                Name = "Bob",
                DepartmentId = computerDepartment.Id
            };

            //context.Students.AddRange(student1, student2);
            //context.SaveChanges();

            Course course1 = new Course
            {
                Title = "Database Systems"
            };
            Course course2 = new Course
            {
                Title = "Operating Systems"
            };
            //context.Courses.AddRange(course1, course2);
            //context.SaveChanges();

            //student1.Courses = new List<Course> { course1, course2 };
            //student2.Courses = new List<Course> { course1 };
            //context.SaveChanges();


            var students = context.Students
                .Where(s => s.DepartmentId == computerDepartment.Id)
                .Include(s => s.Courses)
                .Select(s => new
                {
                    StudentName = s.Name,
                    Course = s.Courses.Select(c => c.Title).ToList(),
                    Department = s.Department.Name
                });

            foreach(var student in students)
            {
                Console.WriteLine($"Student: {student.StudentName}, Department: {student.Department}, Courses: {string.Join(", ", student.Course)}");
            }

        }
    }
}
