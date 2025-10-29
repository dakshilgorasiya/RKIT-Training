using EFCoreDemo.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks.Dataflow;

namespace EFCoreDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Scaffold-DbContext "Server=localhost;user=root;password=********;database=employee_payroll" Pomelo.EntityFrameworkCore.MySql -OutputDir Models

            EmployeePayrollContext context = new EmployeePayrollContext();

            DateOnly startDate = new (2024, 1, 1);
            DateOnly endDate = new(2024, 1, 31);

            var departmentCost = context.T01s
                                    .Join(context.T02s,
                                        t01 => t01.T01f03,
                                        t02 => t02.T02f01,
                                        (t01, t02) => new { t01, t02 })
                                    .Join(context.T03s,
                                        joined => joined.t01.T01f01,
                                        t03 => t03.T03f01,
                                        (joined, t03) => new { joined.t01, joined.t02, t03 })
                                    .Where(x => x.t03.T03f02 >= startDate && x.t03.T03f02 <= endDate)
                                    .GroupBy(
                                        x => new { x.t02.T02f01, x.t02.T02f02 },
                                        (key, group) => new
                                        {
                                            DepartmentId = key.T02f01,
                                            DepartmentName = key.T02f02,
                                            TotalCost = group.Sum(g => g.t03.T03f03)
                                        }
                                    );

            foreach(var department in departmentCost )
            {
                Console.WriteLine( department );
            }

        }
    }
}
