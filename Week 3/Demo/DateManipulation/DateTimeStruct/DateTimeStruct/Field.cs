using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeStruct
{
    internal class Field
    {
        static void Main(string[] args)
        {
            // Represent largest possible value of DateTime
            Console.WriteLine(DateTime.MaxValue); // 31/12/9999 11:59:59 pm

            // Represent smallest possible value of DateTime
            Console.WriteLine(DateTime.MinValue); // 01/01/0001 12:00:00 am

            // Represent unix epoch time
            Console.WriteLine(DateTime.UnixEpoch); // 01/01/1970 12:00:00 am
        }
    }
}
