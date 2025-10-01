using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSpanStruct
{
    internal class Operator
    {
        static void Main(string[] args)
        {
            TimeSpan ts1 = new TimeSpan(5, 10, 15, 20, 250); // 5 days, 10 hours, 15 minutes, 20 seconds, 250 milliseconds
            TimeSpan ts2 = new TimeSpan(2, 5, 10, 15, 500); // 2 days, 5 hours, 10 minutes, 15 seconds, 500 milliseconds
            TimeSpan ts3 = new TimeSpan(-5, -4, -3, -2, -100); // -5 days, -4 hours, -3 minutes, -2 seconds, -100 milliseconds

            // Addition
            Console.WriteLine(ts1 + ts2); // 7.15:25:35.7500000

            // Division
            Console.WriteLine(ts1 / 2); // 2.17:07:37.6250000
            Console.WriteLine(ts1 / ts2); // 2.4497506732735856

            // Equality
            Console.WriteLine(ts1 == ts2); // False

            // Inequality
            Console.WriteLine(ts1 != ts2); // True

            // Greater than
            Console.WriteLine(ts1 > ts2); // True

            // Greater than or equal to
            Console.WriteLine(ts1 >= ts2); // True

            // Less than
            Console.WriteLine(ts1 < ts2); // False

            // Less than or equal to
            Console.WriteLine(ts1 <= ts2); // False

            // Multiplication
            Console.WriteLine(ts1 * 2); // 10.20:30:40.5000000
            Console.WriteLine(2 * ts1); // 10.20:30:40.5000000

            // Subtraction
            Console.WriteLine(ts1 - ts2); // 3.05:04:04.7500000

            // Unary negation
            Console.WriteLine(-ts1); // -5.10:15:20.2500000

            // Unary plus
            Console.WriteLine(+ts3); // -5.04:03:02.1000000
        }
    }
}
