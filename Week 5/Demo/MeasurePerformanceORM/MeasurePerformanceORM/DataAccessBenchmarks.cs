using BenchmarkDotNet.Attributes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ServiceStack.OrmLite;
using System.Data;

namespace MeasurePerformanceORM
{
    [MemoryDiagnoser]
    public class DataAccessBenchmarks
    {
        private string connectionString = "Server=localhost;Database=employee;User=root;Password=Dakshil@123;";

        private int departmentId = 1;

        private OrmLiteConnectionFactory dbFactory;

        [GlobalSetup]
        public void GlobalSetUp()
        {
            dbFactory = new OrmLiteConnectionFactory(connectionString, MySqlDialect.Provider);
        }

        [Benchmark(Baseline = true)]
        public async Task FetchWithAdoNet()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string query = "select t01f01, t01f02, t01f03 from t01 where t01f01 = @departmentId";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@departmentId", departmentId);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            T01 t01 = new T01
                            {
                                T01f01 = reader.GetInt32(0),
                                T01f02 = reader.GetString(1),
                                T01f03 = reader.GetString(2)
                            };
                        }
                    }
                }
            }
        }

        [Benchmark]
        public async Task FetchWithDapper()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "select t01f01, t01f02, t01f03 from t01 where t01f01 = @departmentId";
                T01? result = await connection.QueryFirstOrDefaultAsync<T01>(query, new { departmentId = departmentId });
            }
        }

        [Benchmark]
        public async Task FetchWithOrmLite()
        { 
            using(IDbConnection db = dbFactory.OpenDbConnection())
            {
                T01 result = await db.SingleByIdAsync<T01>(departmentId);
            }
        }

        [Benchmark]
        public async Task FetchWithEntityFrameworkCore()
        {
            using (var context = new Models.employeeContext())
            {
                Models.T01? result = await context.T01s.FindAsync(departmentId);
            }
        }
    }
}
