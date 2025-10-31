using ORMLightDemo.Models;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System.Data;

namespace ORMLightDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "server=localhost;database=employee;user=root;password=Dakshil@123;";

            var dbFactory = new OrmLiteConnectionFactory(connectionString, MySqlDialect.Provider);

            using (IDbConnection db = dbFactory.OpenDbConnection())
            {
                // READ


                //List<T01> t01s = db.Select<T01>();

                //foreach(var department in t01s)
                //{
                //    Console.WriteLine($"{department.T01F01}, {department.T01F02}, {department.T01F03}");
                //}
                //Console.WriteLine();


                //var engineeringDepartment = db.SingleById<T01>(1);

                //Console.WriteLine($"{engineeringDepartment.T01F01}, {engineeringDepartment.T01F02}, {engineeringDepartment.T01F03}");
                //Console.WriteLine();

                //List<T01> mumbaiDepartments = db.Select<T01>(d => d.T01F03 == "Mumbai");

                //foreach(var department in mumbaiDepartments)
                //{
                //    Console.WriteLine($"{department.T01F01}, {department.T01F02}, {department.T01F03}");
                //}


                // INSERT
                var newDepartment = new T01
                {
                    T01F01 = 12,
                    T01F02 = ".NET",
                    T01F03 = "Anand"
                };

                //long departmentId = db.Insert(newDepartment);
                //Console.WriteLine(departmentId);

                // Update
                //T01 forUpdate = db.Single<T01>(d => d.T01F01 == 2);
                //if(forUpdate != null)
                //{
                //    forUpdate.T01F02 = "Marketing";
                //    db.Update(forUpdate);
                //}



                // DELETE
                //db.DeleteById<T01>(12);

                //db.Delete<T01>(d => d.T01F03 == "Mumbai");



                // SP
                //List<GetEmployeeByDepartmentResult> result = db.SqlList<GetEmployeeByDepartmentResult>("CALL GET_EMPLOYEE_BY_DEPARTMENT(@p_dept_name)", new { 
                //    p_dept_name = "Engineering"
                //});

                //foreach(var resultItem in result)
                //{
                //    Console.WriteLine($"{resultItem.T02F01}, {resultItem.T02F02}, {resultItem.T02F03}");
                //}


                using (var cmd = db.SqlProc("count_emp"))
                {
                    IDbDataParameter outputParamProc = cmd.AddParam("p_count", direction: ParameterDirection.Output, dbType: DbType.Int32);

                    cmd.ExecuteNonQuery();

                    int count = (int)outputParamProc.Value;

                    Console.WriteLine(count);
                }


                // Transaction
                using(IDbTransaction transaction = db.OpenTransaction())
                {
                    var newDepartment2 = new T01
                    {
                        T01F01 = 13,
                        T01F02 = "QA",
                        T01F03 = "Anand"
                    };

                    db.Insert(newDepartment2);

                    transaction.Rollback();
                }


            }
        }
    }
}
