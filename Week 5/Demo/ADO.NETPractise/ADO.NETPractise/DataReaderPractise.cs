using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NETPractise
{
    internal class DataReaderPractise
    {
        static void Main(string[] args)
        {
            string connectionString = "server=localhost;user=root;password=Dakshil@123;database=employee";

            string query = "SELECT T02F01, T02F02, T02F03, T01F02 FROM T02 INNER JOIN T01 ON T02F08 = T01F01";

            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlCommand command = new MySqlCommand(query, connection);

            connection.Open();

            MySqlDataReader reader = command.ExecuteReader();

            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    Console.WriteLine($"{reader.GetInt32(0)}, {reader.GetString(1)} {reader.GetString(2)}, {reader.GetString(3)}");
                }
            }
        }
    }
}
