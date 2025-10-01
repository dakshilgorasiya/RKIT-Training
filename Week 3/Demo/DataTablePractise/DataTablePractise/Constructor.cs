using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DataTablePractise
{
    internal class Constructor
    {
        static void Main(string[] args)
        {
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable("MyTable");
            DataTable dt3 = new DataTable("MyTable", "MyTableNamespace"); // namespace is used in XML representation of DataSet it will be added to xml root element's xmlns attribute
        }
    }
}
