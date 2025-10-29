using Dapper;
using DapperDemo.Models;
using MySqlConnector;

namespace DapperDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string connectionString = "Server=localhost;Database=employee;User=root;Password=Dakshil@123";

            await using var connection = new MySqlConnection(connectionString);

            await connection.OpenAsync();

            await using var transaction = await connection.BeginTransactionAsync();

            try
            {


                string getT01 = "SELECT * FROM T01";

                var allDepartments = await connection.QueryAsync<T01>(getT01, transaction: transaction);

                //foreach (var department in allDepartments)
                //{
                //    Console.WriteLine($"{department.T01F01}, {department.T01F02}, {department.T01F03}");
                //}

                string getOne = "SELECT * FROM T01 WHERE T01F01 = @DepartmentId";

                int idToFind = 1;

                var singleDepartment = await connection.QueryFirstOrDefaultAsync<T01>(getOne, new {DepartmentId = idToFind}, transaction: transaction);

                //if(singleDepartment != null)
                //{
                //    Console.WriteLine($"{singleDepartment.T01F01}, {singleDepartment.T01F02}, {singleDepartment.T01F03}");
                //}


                // INSERT
                var newDepartment = new T01
                {
                    T01F01 = 12,
                    T01F02 = "dotnet",
                    T01F03 = "Mumbai"
                };

                string sqlInsert = "INSERT INTO T01(T01F01, T01F02, T01F03) VALUES (@T01F01, @T01F02, @T01F03)";

                //int rowAffected = await connection.ExecuteAsync(sqlInsert, newDepartment, transaction: transaction);

                //if(rowAffected > 0)
                //{
                //    Console.WriteLine("New department inserted successfully");
                //}


                // UPDATE
                var updatedDepartment = new T01
                {
                    T01F01 = 12,
                    T01F02 = "C#",
                    T01F03 = "Anand"
                };

                string sqlUpdate = "UPDATE T01 SET T01F02 = @T01F02, T01F03 = @T01F03 WHERE T01F01 = @T01F01";

                //int rowUpdated = await connection.ExecuteAsync(sqlUpdate, updatedDepartment, transaction: transaction);

                //if(rowUpdated > 0)
                //{
                //    Console.WriteLine("Department updated");
                //}


                // DELETE
                int idToDelete = 12;

                string sqlDelete = "DELETE FROM T01 WHERE T01F01 = @T01F01";

                //int rowDeleted = await connection.ExecuteAsync(sqlDelete, new { T01F01 = idToDelete }, transaction: transaction);

                //if(rowDeleted > 0)
                //{
                //    Console.WriteLine("Department deleted");
                //}


                // SP
                string spName = "GET_EMPLOYEE_BY_DEPARTMENT";

                var employees = await connection.QueryAsync<T02>(
                    spName,
                    new { p_dept_name = "Engineering" },
                    commandType: System.Data.CommandType.StoredProcedure,
                    transaction: transaction
                    );

                //foreach ( var employee in employees )
                //{
                //    Console.WriteLine($"{employee.T02F01}, {employee.T02F02}, {employee.T02F03}");
                //}


                // SP with out parameter
                var parameters = new DynamicParameters();

                parameters.Add("@p_count", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);

                string spName2 = "count_emp";
                await connection.ExecuteAsync(spName2, parameters, commandType: System.Data.CommandType.StoredProcedure, transaction: transaction);

                int count = parameters.Get<int>("@p_count");

                Console.WriteLine("Count = " + count);


                // Transaction
                string deleteAll = "DELETE FROM T01";

                await connection.ExecuteAsync(deleteAll, transaction: transaction);

                throw new Exception("Something went wrong");

                await transaction.CommitAsync();

                Console.WriteLine("Transaction commited");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                Console.WriteLine("Transaction rollbacked : " + ex.Message);
            }
        }
    }
}
