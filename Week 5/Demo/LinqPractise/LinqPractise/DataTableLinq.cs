using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LinqPractise
{
    internal class DataTableLinq
    {
        static void Main(string[] args)
        {
            // Create Departments Table
            var departmentsTable = new DataTable("Departments");
            departmentsTable.Columns.Add("DepartmentID", typeof(int));
            departmentsTable.Columns.Add("DepartmentName", typeof(string));

            departmentsTable.Rows.Add(1, "Engineering");
            departmentsTable.Rows.Add(2, "Sales");
            departmentsTable.Rows.Add(3, "Human Resources");

            // Create Employees Table
            var employeesTable = new DataTable("Employees");
            employeesTable.Columns.Add("EmployeeID", typeof(int));
            employeesTable.Columns.Add("Name", typeof(string));
            employeesTable.Columns.Add("DepartmentID", typeof(int));
            employeesTable.Columns.Add("Salary", typeof(decimal));
            employeesTable.Columns.Add("HireDate", typeof(DateTime));

            employeesTable.Rows.Add(101, "Alice", 1, 95000, new DateTime(2022, 6, 1));
            employeesTable.Rows.Add(102, "Bob", 1, 110000, new DateTime(2021, 3, 15));
            employeesTable.Rows.Add(103, "Charlie", 2, 80000, new DateTime(2023, 1, 20));
            employeesTable.Rows.Add(104, "David", 2, 82000, new DateTime(2022, 11, 5));
            employeesTable.Rows.Add(105, "Eve", 1, 120000, new DateTime(2020, 8, 22));
            employeesTable.Rows.Add(106, "Frank", 3, 75000, new DateTime(2023, 5, 10));
            employeesTable.Rows.Add(107, "Alice", 1, 95000, new DateTime(2022, 6, 1));

            var employees = employeesTable.AsEnumerable();
            var departments = departmentsTable.AsEnumerable();


            // Find all employees in the "Engineering" department (DepartmentID 1), and order them by salary from highest to lowest.
            var engineeringEmployeeMethod = departments.Where(d => d.Field<string>("DepartmentName") == "Engineering")
                                                 .Join(employees,
                                                 d => d.Field<int>("DepartmentID"),
                                                 e => e.Field<int>("DepartmentID"),
                                                 (d, e) => new {
                                                    Name = e.Field<string>("Name"),
                                                    Salary = e.Field<decimal>("Salary")
                                                 })
                                                 .OrderByDescending(e => e.Salary);

            var engineeringEmployeeQuery = from d in departments
                                           join e in employees on d.Field<int>("DepartmentID") equals e.Field<int>("DepartmentID")
                                           where d.Field<string>("DepartmentName") == "Engineering"
                                           orderby e.Field<decimal>("Salary") descending
                                           select new
                                           {
                                               Name = e.Field<string>("Name"),
                                               Salary = e.Field<decimal>("Salary")
                                           };


            //foreach (var emp in engineeringEmployeeQuery)
            //{
            //    Console.WriteLine($"Name: {emp.Name}, Salary: {emp.Salary}");
            //}



            // Calculate the number of employees, the average salary, and the maximum salary for each department.
            var departmentStatsMethod = employees.GroupBy(d => d.Field<int>("DepartmentID"))
                                                   .Join(departments,
                                                   empGroup => empGroup.Key,
                                                   d => d.Field<int>("DepartmentID"),
                                                   (empGroup, d) => new { 
                                                        DepartmentName = d.Field<string>("DepartmentName"),
                                                        EmployeeCount = empGroup.Count(),
                                                        AverageSalary = empGroup.Average(e => e.Field<decimal>("Salary")),
                                                        MaximumSalary = empGroup.Sum(e => e.Field<decimal>("Salary"))
                                                   });

            var departmentStatsQuery =from e in employees
                                        group e by e.Field<int>("DepartmentID") into empGroup
                                        join d in departments on empGroup.Key equals d.Field<int>("DepartmentID")
                                        select new
                                        {
                                            DepartmentName = d.Field<string>("DepartmentName"),
                                            EmployeeCount = empGroup.Count(),
                                            AverageSalary = empGroup.Average(emp => emp.Field<decimal>("Salary")),
                                            MaximumSalary = empGroup.Sum(emp => emp.Field<decimal>("Salary"))
                                        };



            //foreach (var emp in departmentStatsQuery)
            //{
            //    Console.WriteLine($"Department: {emp.DepartmentName}, Count: {emp.EmployeeCount}, Avg: {emp.AverageSalary}, Max: {emp.MaximumSalary}");
            //}



            // Find the 2nd and 3rd highest-paid employees across the entire company.
            var pagedEmployeeMethod = employees.OrderByDescending(e => e.Field<decimal>("Salary"))
                                               .Skip(1)
                                               .Take(2)
                                               .Select(e => new
                                               {
                                                   Name = e.Field<string>("Name"),
                                                   Salary = e.Field<decimal>("Salary")
                                               });

            var pagedEmployeeQuery = (from e in employees
                                      orderby e.Field<decimal>("Salary") descending
                                      select new
                                      {
                                          Name = e.Field<string>("Name"),
                                          Salary = e.Field<decimal>("Salary")
                                      }).Skip(1).Take(2);

            //foreach (var emp in pagedEmployeeQuery)
            //{
            //    Console.WriteLine($"Name: {emp.Name}, Salary: {emp.Salary}");
            //}

            var dupligateEntry = from e1 in employees
                                 join e2 in employees on e1 equals e2
                                 where e1 == e2
                                 select e1;


            //foreach( var e in dupligateEntry )
            //{
            //    Console.WriteLine($"{e.Table.Rows.Count}");
            //}


            // Quantifiable operator

            // ANY
            bool isQaDepartment = departments.Any(d => d.Field<string>("DepartmentName") == "QA");
            Console.WriteLine(isQaDepartment);

            bool isAllEmployeeReceiveMoreThan50000 = employees.All(d => d.Field<decimal>("Salary") > 50000);
            Console.WriteLine(isAllEmployeeReceiveMoreThan50000);


            // Conversion
            DataTable engineeringEmployeeTable = employees.Where(e => e.Field<int>("DepartmentId") == 1).CopyToDataTable();

            //foreach(DataRow row in engineeringEmployeeTable.Rows)
            //{
            //    Console.WriteLine($"{row["Name"]}");
            //}
        }
    }
}
