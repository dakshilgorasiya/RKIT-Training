using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTablePractise
{
    internal class Method
    {
        static void Main(string[] args)
        {
            DataSet dataSet = new DataSet("University");

            DataTable StudentTable = new DataTable("Student");
            StudentTable.Columns.Add("ID", typeof(int));
            StudentTable.Columns.Add("Name", typeof(string));
            StudentTable.Columns.Add("Age", typeof(int));
            StudentTable.Columns.Add("Department", typeof(int));
            StudentTable.PrimaryKey = new DataColumn[] { StudentTable.Columns["ID"] };
            dataSet.Tables.Add(StudentTable);

            DataTable DepartmentTable = new DataTable("Department");
            DepartmentTable.Columns.Add("ID", typeof(int));
            DepartmentTable.Columns.Add("Name", typeof(string));
            DepartmentTable.PrimaryKey = new DataColumn[] { DepartmentTable.Columns["ID"] };
            dataSet.Tables.Add(DepartmentTable);

            DataRelation dataRelation = dataSet.Relations.Add("StudentDepartment",
                DepartmentTable.Columns["ID"],              // Parent Column
                StudentTable.Columns["Department"]);        // Child Column


            DepartmentTable.Rows.Add(1, "CSE");
            DepartmentTable.Rows.Add(2, "IT");

            StudentTable.Rows.Add(1, "Alice", 21, 1);
            StudentTable.Rows.Add(2, "Bob", 22, 2);
            StudentTable.Rows.Add(3, "Charlie", 23, 1);
            StudentTable.Rows.Add(4, "David", 24, 2);
            StudentTable.Rows.Add(5, "Eve", 21);

            // AcceptChanges
            DepartmentTable.AcceptChanges(); // It will set the RowState of all rows to Unchanged

            // Clear -> Delete all data
            StudentTable.Clear();

            // Clone -> It will copy the structure of the table (columns, constraints, etc.) but not the data
            DataTable clonedTable = DepartmentTable.Clone();


            // Comute -> It computes an aggregate function on a column of the table
            // expression, filter
            int count = (int)DepartmentTable.Compute("COUNT(ID)", "Name LIKE 'C%'");
            Console.WriteLine(count); // 1

            // Copy -> It copies both the structure and the data of the table
            DataTable copiedTable = DepartmentTable.Copy();

            // CreateDataReader -> It provides a way to read data in a forward-only stream
            using (var reader = DepartmentTable.CreateDataReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["ID"]}, Name: {reader["Name"]}");
                }
            }

            // GetChanges -> It returns a copy of the table that contains all changes made since the last AcceptChanges call
            DepartmentTable.Rows[0]["Name"] = "Computer Science"; // Modify a row
            DataTable changes = DepartmentTable.GetChanges();
            if (changes != null)
            {
                foreach (DataRow row in changes.Rows)
                {
                    Console.WriteLine($"Changed Row - ID: {row["ID"]}, Name: {row["Name"]}, RowState: {row.RowState}");
                }
            }
            else
            {
                Console.WriteLine("No changes found.");
            }

            // Load -> It populates the table with data from a data source using a DataReader
            // DepartmentTable.Load(reader); // Assuming 'reader' is a valid IDataReader

            // LoadDataRow -> It finds and updates an existing row or creates a new row
            object[] values = new object[] { 3, "Chemistry" };
            DataRow loadedRow = DepartmentTable.LoadDataRow(values, LoadOption.Upsert);
            Console.WriteLine($"Loaded Row - ID: {loadedRow["ID"]}, Name: {loadedRow["Name"]}, RowState: {loadedRow.RowState}");

            // Merge -> It merges the data from another DataTable into the current table
            // DepartmentTable.Merge(anotherTable); // Assuming 'anotherTable' is a valid DataTable

            // NewRow -> It creates a new DataRow with the same schema as the table
            DataRow newRow = DepartmentTable.NewRow();
            newRow["ID"] = 4;
            newRow["Name"] = "Mathematics";
            DepartmentTable.Rows.Add(newRow);

            // Reset
            //DepartmentTable.Reset(); // It clears all data and schema information from the table

            // Select
            // ()
            // (filter)
            // (filter, sort)
            foreach (DataRow row in DepartmentTable.Select())
            {
                Console.WriteLine($"ID: {row["ID"]}, Name: {row["Name"]}");
            }

            foreach(DataRow row in DepartmentTable.Select("Name LIKE 'C%'"))
            {
                Console.WriteLine($"Filtered Row - ID: {row["ID"]}, Name: {row["Name"]}");
            }

            // ToString
            Console.WriteLine(DepartmentTable.ToString()); // Tablename, namespace

            // WriteXml
            // XmlWriteMode -> IgnoreSchema, WriteSchema, DiffGram(default -> rowstate)
            DepartmentTable.WriteXml("DepartmentTable.xml", XmlWriteMode.WriteSchema);

            StudentTable.WriteXml("StudentTable.xml", true);

            // WriteXmlSchema
            DepartmentTable.WriteXmlSchema("DepartmentTableSchema.xml");

            DataTable restoredTable = new DataTable();
            restoredTable.ReadXml("DepartmentTable.xml");
            foreach (DataRow row in restoredTable.Rows)
            {
                Console.WriteLine($"Restored Row - ID: {row["ID"]}, Name: {row["Name"]}");
            }
        }
    }
}
