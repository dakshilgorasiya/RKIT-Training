using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ADO.NETPractise
{
    internal class CommandPractise
    {
        static void Main(string[] args)
        {
            string connectionString = "server=localhost;user=root;password=Dakshil@123;database=employee";

            MySqlConnection connection = new MySqlConnection(connectionString);

            // INSERT
            string insertQuery = "INSERT INTO T01(T01F01, T01F02, T01F03) VALUES (@id, @name, @location)";

            connection.Open();

            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            command.Parameters.AddWithValue("@id", 11);
            command.Parameters.AddWithValue("@name", "iOS");
            command.Parameters.AddWithValue("@location", "delhi");

            int rows = command.ExecuteNonQuery();

            connection.Close();

            Console.WriteLine($"Affected rows : {rows}");


            // Procedures

            connection.Open();

            MySqlCommand command2 = new MySqlCommand("GET_EMPLOYEE_BY_DEPARTMENT", connection);


            command2.CommandType = System.Data.CommandType.StoredProcedure;

            command2.Parameters.AddWithValue("p_dept_name", "Engineering");

            MySqlDataReader reader = command2.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader.GetInt32(0)} {reader.GetString(1)} {reader.GetString(2)}");
            }

            connection.Close();

            // with out parameter
            connection.Open();

            MySqlCommand command3 = new MySqlCommand("count_emp", connection);

            command3.CommandType = System.Data.CommandType.StoredProcedure;

            command3.Parameters.Add("p_count", MySqlDbType.Int32);
            command3.Parameters["p_count"].Direction = System.Data.ParameterDirection.Output;

            command3.ExecuteNonQuery();

            connection.Close();

            int count = (int)command3.Parameters["p_count"].Value;
            Console.WriteLine(count);



            // Transaction

            connection.Open();

            MySqlTransaction transaction = connection.BeginTransaction();

            try
            {
                MySqlCommand insertCommand = new MySqlCommand("", connection, transaction);
                insertCommand.CommandText = "DELETE FROM T01";

                throw new Exception("Somethind went wrong");

                transaction.Commit();

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine("Transaction Rollbacked" + ex.Message);
            }

            connection.Close();
        }
    }
}
