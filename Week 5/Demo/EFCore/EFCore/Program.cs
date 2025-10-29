using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace EFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeContext context = new EmployeeContext();


            // READ
            List<T02> data = context.T02s.ToList();
            //foreach (var item in data)
            //{
            //    Console.WriteLine($"{item.T02f01} {item.T02f02} {item.T02f03} {item.T02f04} {item.T02f05} {item.T02f06} {item.T02f07} {item.T02f08}");
            //}

            // Employee name with departmentname
            var data2 = context.T02s
                               .Join(context.T01s,
                                    t02 => t02.T02f08,
                                    t01 => t01.T01f01,
                                    (t02, t01) => new
                                    {
                                        EmpName = t02.T02f02,
                                        DeptName = t01.T01f02
                                    });

            //foreach (var item in data2)
            //{
            //    Console.WriteLine($"{item.EmpName} {item.DeptName}");
            //}



            // DELETE
            var data3 = context.T01s.FirstOrDefault(x => x.T01f01 == 7);
            //context.T01s.Remove(data3);
            //context.SaveChanges();


            // INSERT
            T01 t01 = new T01()
            {
                T01f01 = 7,
                T01f02 = "Android",
                T01f03 = "anand"
            };
            //context.T01s.Add(t01);
            //context.SaveChanges();


            // UPDATE
            var data4 = context.T01s.FirstOrDefault(x => x.T01f01 == 7);
            if (data4 != null)
            {
                //data4.T01f02 = "iOS";
                //context.SaveChanges();
            }




            // STORED PROCEDURE
            string departmentName = "Engineering";
            List<GetEmployeeByDepartmentResult> data5 = context.GetEmployeeByDepartmentResults.FromSqlInterpolated($"CALL get_employee_by_department({departmentName})").ToList();

            foreach (GetEmployeeByDepartmentResult item in data5)
            {
                Console.WriteLine($"{item.T02F01} {item.T02F02} {item.T02F03}");
            }


           using (var transaction = context.Database.BeginTransaction())
            {
                context.Database.ExecuteSqlRaw("Delete from t03");

                transaction.CreateSavepoint("NAME");

                transaction.RollbackToSavepoint("NAME");

                transaction.Rollback();
            }
        }
    }
}
