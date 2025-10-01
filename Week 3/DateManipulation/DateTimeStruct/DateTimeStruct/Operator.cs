using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeStruct
{
    internal class Operator
    {
        static void Main(string[] args)
        {
            DateTime dt1 = new DateTime(2025, 10, 10, 15, 10, 15, 45); // 10/10/2025 3:10:15 pm
            DateTime dt2 = new DateTime(2023, 5, 5, 10, 5, 5, 25); // 05/05/2023 10:05:05 am
            TimeSpan duration = new TimeSpan(5, 30, 0); // 5 hours, 30 minutes, 0 seconds

            // Addition
            Console.WriteLine(dt1 + duration); // 10/10/2025 8:40:15 pm

            // Subtraction
            Console.WriteLine(dt1 - duration); // 10/10/2025 9:40:15 am

            // Equality
            Console.WriteLine(dt1 == dt2); // False

            // Inequality
            Console.WriteLine(dt2 != dt1); // True

            // Greater than
            Console.WriteLine(dt1 > dt2); // True

            // Greater than or equal to
            Console.WriteLine(dt1 >= dt2); // True

            // Less than
            Console.WriteLine(dt1 < dt2); // False

            // Less than or equal to
            Console.WriteLine(dt1 <= dt2); // False
        }
    }
}
