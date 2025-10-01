using System.Data;
using MySql.Data.MySqlClient;

namespace ADONETPractise
{
    static class MyDataReader
    {
        private static string _connectionString = "server=localhost;user=root;password=Dakshil@123;database=employee";

        public static void ReadData()
        {
            MySqlConnection connection = new MySqlConnection(_connectionString);

            try
            {
                string query = "SELECT T02F02, T02F03, T01F02 FROM T01 INNER JOIN T02 ON T01F01 = T02F08;";

                MySqlCommand command = new MySqlCommand(query, connection);

                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader.GetString(0)} {reader.GetString(1)} {reader.GetString(2)}");
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }

    static class MyDataAdapter
    {
        private static string _connectionString = "server=localhost;user=root;password=Dakshil@123;database=employee";

        public static void FillData()
        {
            MySqlConnection connection = new MySqlConnection(_connectionString);

            try
            {
                string query = "SELECT T02F02, T02F03, T01F02 FROM T01 INNER JOIN T02 ON T01F01 = T02F08;";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);

                DataTable table = new DataTable();

                adapter.Fill(table);

                foreach (DataRow row in table.Rows)
                {
                    Console.WriteLine($"{row["T02F02"]} {row["T02F03"]} {row["T01F02"]}");
                }

                // use adapter.Update(table); to update the database with changes made to the DataTable
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

        }
    }
    
    static class InsertValue
    {
        private static string _connectionString = "server=localhost;user=root;password=Dakshil@123;database=employee";
        public static void InsertData()
        {
            MySqlConnection connection = new MySqlConnection(_connectionString);
            try
            {
                string query = "INSERT INTO T01 (T01F01, T01F02, T01F03) VALUES (@id, @name, @location);";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", 6);
                command.Parameters.AddWithValue("@name", "Accounts");
                command.Parameters.AddWithValue("@location", "Mumbai");
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} row(s) inserted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }

    static class ExecuteProcedure
    {
        private static string _connectionString = "server=localhost;user=root;password=Dakshil@123;database=employee";

        public static void CallProcedure()
        {
            MySqlConnection connection = new MySqlConnection(_connectionString);
            try
            {
                string procedureName = "GET_EMPLOYEE_BY_DEPARTMENT"; // Replace with your procedure name
                MySqlCommand command = new MySqlCommand(procedureName, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_dept_name", "Sales");
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader(); // If procedure insert/update/delete use ExecuteNonQuery
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["T02F01"]} {reader["T02F02"]} {reader["T02F03"]}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }   

        public static void CallProcedureWithOutputParam()
        {
            MySqlConnection connection = new MySqlConnection(_connectionString);
            try
            {
                string procedureName = "COUNT_EMPLOYEE"; // Replace with your procedure name
                MySqlCommand command = new MySqlCommand(procedureName, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_dept_name", "Sales");
                command.Parameters.Add("@p_count", MySqlDbType.Int32);
                command.Parameters["@p_count"].Direction = ParameterDirection.Output;
                connection.Open();
                command.ExecuteNonQuery(); // For output parameters use ExecuteNonQuery
                int empCount = Convert.ToInt32(command.Parameters["@p_count"].Value);
                Console.WriteLine($"Employee count in Sales department: {empCount}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //MyDataReader.ReadData();
            //MyDataAdapter.FillData();
            //InsertValue.InsertData();
            //ExecuteProcedure.CallProcedure();
            //ExecuteProcedure.CallProcedureWithOutputParam();
        }
    }
}
