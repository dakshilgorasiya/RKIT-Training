using System.Data;

namespace DataTablePractise
{
    internal class Program
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

            // Create forign key relationship
            DataRelation relation = dataSet.Relations.Add("StudentDepartment",
                DepartmentTable.Columns["ID"],              // Parent Column
                StudentTable.Columns["Department"]);        // Child Column

            relation.ChildKeyConstraint.DeleteRule = Rule.Cascade;
            relation.ChildKeyConstraint.UpdateRule = Rule.Cascade;


            // Foreign key constraint with cascade delete and update it doesn't give navigation
            //ForeignKeyConstraint fk = new ForeignKeyConstraint(
            //    "FKStudentDepartment",
            //    DepartmentTable.Columns["ID"],              // Parent Column
            //    StudentTable.Columns["Department"]      // Child Column
            //);

            //fk.DeleteRule = Rule.Cascade;
            //fk.UpdateRule = Rule.Cascade;
            //StudentTable.Constraints.Add(fk);

            DepartmentTable.Rows.Add(1, "CSE");
            DepartmentTable.Rows.Add(2, "IT");

            StudentTable.Rows.Add(1, "Alice", 21, 1);
            StudentTable.Rows.Add(2, "Bob", 22, 2);
            StudentTable.Rows.Add(3, "Charlie", 23, 1);
            StudentTable.Rows.Add(4, "David", 24, 2);
            StudentTable.Rows.Add(5, "Eve", 21);

            //DepartmentTable.Rows.Remove(DepartmentTable.Rows.Find(1));

            foreach (DataRow student in StudentTable.Rows)
            {
                Console.WriteLine($"Student: {student["Name"]}, Age: {student["Age"]}");
                // Get the related department using the relation
                DataRow department = student.GetParentRow("StudentDepartment");
                if (department != null)
                {
                    Console.WriteLine($"Department: {department["Name"]}");
                }
                Console.WriteLine();
            }

            DataRow[] result = StudentTable.Select("Age > 22", "Age DESC");
            Console.WriteLine("Student with Age > 22:");
            foreach (DataRow row in result)
            {
                Console.WriteLine($"Student: {row["Name"]}, Age: {row["Age"]}");
            }

            DataRow[] r2 = StudentTable.Select("Department IS NULL");
            Console.WriteLine("\nStudent with no Department:");
            foreach (DataRow row in r2)
            {
                Console.WriteLine($"Student: {row["Name"]}, Age: {row["Age"]}");
            }
        }
    }
}
