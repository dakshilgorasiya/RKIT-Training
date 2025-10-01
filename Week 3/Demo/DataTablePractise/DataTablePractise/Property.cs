using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DataTablePractise
{
    internal class Property
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


            // Properties of DataTable

            Console.WriteLine(StudentTable.CaseSensitive); // False by default

            // It return DataRelationCollection which represents all the parent-child relationships in which this table is the parent table.
            // ReadOnly property
            Console.WriteLine(DepartmentTable.ChildRelations.Count);
            DataRelationCollection drc = DepartmentTable.ChildRelations;
            Console.WriteLine(drc[0].RelationName + " " + drc[0].ParentTable + " " + drc[0].ChildTable);


            // Columns
            // ReadOnly property
            DataColumnCollection dcc = StudentTable.Columns;
            foreach(DataColumn dc in dcc)
            {
                Console.WriteLine(dc.ColumnName + " " + dc.DataType);
            }

            // Constraints
            // ReadOnly property
            ConstraintCollection cc = StudentTable.Constraints;
            foreach(Constraint c in cc)
            {
                Console.WriteLine(c.ConstraintName + " " + c.GetType());
            }

            // DataSet
            // ReadOnly property
            DataSet ds = StudentTable.DataSet;

            // DefaultView
            DataView dv = StudentTable.DefaultView;
            dv.Sort = "Name DESC";
            foreach(DataRowView drv in dv)
            {
                Console.WriteLine(drv["Name"]);
            }

            // HasErrors
            Console.WriteLine(StudentTable.HasErrors); // False

            // IsInitialized
            Console.WriteLine(StudentTable.IsInitialized); // True

            // Locale
            StudentTable.Locale = new System.Globalization.CultureInfo("in-IN");
            Console.WriteLine(StudentTable.Locale); // in-IN

            // MinimumCapacity
            // Reserve memory for at least the specified number of rows.
            // Use this in case when performance is critical and you know in advance how many rows the table will contain.
            Console.WriteLine(StudentTable.MinimumCapacity); // 50

            // Namespace\
            StudentTable.Namespace = "http://www.example.com/student";
            Console.WriteLine(StudentTable.Namespace); // Empty string by default

            // ParentRelations
            DataRelationCollection dataRelation1 = StudentTable.ParentRelations;
            foreach(DataRelation dr in dataRelation1)
            {
                Console.WriteLine(dr.RelationName + " " + dr.ParentTable + " " + dr.ChildTable);
            }

            // PrimaryKey
            DataColumn[] primaryKey = StudentTable.PrimaryKey;
            foreach(DataColumn dc in primaryKey)
            {
                Console.WriteLine(dc.ColumnName);
            }

            // RemotingFormat (XML or Binary)
            Console.WriteLine(StudentTable.RemotingFormat);

            DataRowCollection rows = StudentTable.Rows;
            foreach(DataRow dr in rows)
            {
                Console.WriteLine(dr["Name"]);
            }

            // TableName
            Console.WriteLine(StudentTable.TableName);
        }
    }
}
