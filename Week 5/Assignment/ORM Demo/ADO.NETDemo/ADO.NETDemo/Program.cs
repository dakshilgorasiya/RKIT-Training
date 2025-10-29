using MySql.Data.MySqlClient;

namespace ADO.NETDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "server=localhost;database=employee_payroll;user=root;password=Dakshil@123";

            MySqlConnection connection = new MySqlConnection(connectionString);

            string query = "SELECT T02F01, T02F02, SUM(T03F03) AS SUMSALARY FROM T01 INNER JOIN T02 ON T01F03 = T02F01 INNER JOIN T03 ON T01F01 = T03F01 WHERE T03F02 BETWEEN @STARTDATE AND @ENDDATE GROUP BY T02F01, T02F02";

            MySqlCommand command = new MySqlCommand(query, connection);

            DateTime startDate = new DateTime(2024, 1, 1);

            DateTime endDate = new DateTime(2024, 1, 31);

            command.Parameters.AddWithValue("STARTDATE", startDate);

            command.Parameters.AddWithValue("ENDDATE", endDate);

            connection.Open();

            MySqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                Console.WriteLine($"{reader.GetInt32(0)} {reader.GetString(1)} {reader.GetDecimal(2)}");
            }
        }
    }
}
