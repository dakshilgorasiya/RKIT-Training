using Dapper;
using DapperDemo.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string connectionString = "Server=localhost;Database=EMPLOYEE_PAYROLL;User=root;Password=Dakshil@123";

            try
            {
                using var connection = new MySqlConnection(connectionString);

                await connection.OpenAsync();

                string query = "SELECT T02F01, T02F02, SUM(T03F03) AS SUMSALARY FROM T01 INNER JOIN T02 ON T01F03 = T02F01 INNER JOIN T03 ON T01F01 = T03F01 WHERE T03F02 BETWEEN @STARTDATE AND @ENDDATE GROUP BY T02F01, T02F02;";

                var result = await connection.QueryAsync<DepartmentWiseCost>(query, 
                    new 
                    {
                        StartDate = new DateTime(2024, 1, 1),
                        EndDate = new DateTime(2024, 1, 31)
                    });

                foreach (DepartmentWiseCost department in result)
                {
                    Console.WriteLine($"{department.T02F01}, {department.T02F02}, {department.SumSalary}");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
