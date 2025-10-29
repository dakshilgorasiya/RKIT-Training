using MySql.Data.MySqlClient;
using System.Data;

namespace ADO.NETPractise
{
    internal class DataAdapterPractise
    {
        static void Main(string[] args)
        {
            string connectionString = "server=localhost;user=root;password=Dakshil@123;database=employee";

            string query = "SELECT * FROM T01";

            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);

            MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);

            connection.Open();

            DataTable T01 = new DataTable();

            adapter.Fill(T01);

            // DELETE
            foreach(DataRow row in T01.Rows)
            {
                if ((string)row["T01F02"] == "iOS")
                {
                    row.Delete();
                }
            }

            // INSERT
            T01.Rows.Add(10, "Android", "Anand");

            // UPDATE
            foreach (DataRow row in T01.Rows)
            {
                if ((int)row["T01F01"] == 1)
                {
                    row["T01F03"] = "Delhi";
                }
            }

            adapter.Update(T01);

            connection.Close();

            // READ
            foreach (DataRow row in T01.Rows)
            {
                Console.WriteLine($"{row["T01F01"]} {row["T01F02"]} {row["T01F03"]}");
            }
        }
    }
}
