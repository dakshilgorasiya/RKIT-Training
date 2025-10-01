using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace TimeSpanStruct
{
    internal class Method
    {
        static void Main(string[] args)
        {
            TimeSpan ts1 = new TimeSpan(5, 10, 15, 20, 250); // 5 days, 10 hours, 15 minutes, 20 seconds, 250 milliseconds
            TimeSpan ts2 = new TimeSpan(2, 5, 10, 15, 500); // 2 days, 5 hours, 10 minutes, 15 seconds, 500 milliseconds

            // Add
            Console.WriteLine(ts1.Add(ts2)); // 7.15:25:35.7500000

            // Compare
            // -1 if ts1 is less than ts2, 0 if they are equal, 1 if ts1 is greater than ts2
            Console.WriteLine(TimeSpan.Compare(ts1, ts2)); // 1

            // CompareTo
            Console.WriteLine(ts1.CompareTo(ts2)); // 1
            Console.WriteLine(ts1.CompareTo((object)ts1)); // 0

            // Divide
            Console.WriteLine(ts1.Divide(2)); // 2.17:07:37.6250000
            Console.WriteLine(ts1.Divide(ts2)); // 2.4497506732735856

            // Duration
            // Returns the absolute value of the TimeSpan
            Console.WriteLine(ts1.Duration()); // 5.10:15:20.2500000

            // Equals
            Console.WriteLine(ts1.Equals(ts2)); // False
            Console.WriteLine(ts1.Equals((object)ts1)); // True
            Console.WriteLine(TimeSpan.Equals(ts1, ts2)); // False

            // FromDays
            Console.WriteLine(TimeSpan.FromDays(1.5)); // 1.12:00:00

            // FromHours
            Console.WriteLine(TimeSpan.FromHours(1.5)); // 01:30:00

            // FromMicroseconds
            Console.WriteLine(TimeSpan.FromMicroseconds(1500000)); // 00:00:01.5000000

            // Other
            // FromMilliseconds, FromMinutes, FromNanoseconds, FromSeconds, FromTicks,

            // GetHashCode
            Console.WriteLine(ts1.GetHashCode()); // -901786141   

            // Multiply
            Console.WriteLine(ts1.Multiply(2)); // 10.20:30:40.5000000

            // Negate
            Console.WriteLine(ts1.Negate()); // -5.10:15:20.2500000

            // Parse
            Console.WriteLine(TimeSpan.Parse("5.10:15:20.2500000", CultureInfo.CreateSpecificCulture("en-IN"))); // 5.10:15:20.2500000

            // ParseExact
            Console.WriteLine(TimeSpan.ParseExact("5.10:15:20.2500000", "d\\.hh\\:mm\\:ss\\.fffffff", CultureInfo.InvariantCulture)); // 5.10:15:20.2500000
            Console.WriteLine(TimeSpan.ParseExact("5.10:15", new string[] { "d\\.hh\\:mm\\:ss\\.fffffff", "d\\.hh\\:mm" }, CultureInfo.InvariantCulture, TimeSpanStyles.AssumeNegative)); // -5.10:15:00

            // Subtract
            Console.WriteLine(ts1.Subtract(ts2)); // 3.05:04:04.7500000 

            // ToString
            Console.WriteLine(ts1.ToString()); // 5.10:15:20.2500000
            // c -> [-][d.]hh:mm:ss[.fffffff]
            Console.WriteLine(ts1.ToString("c")); // 5.10:15:20.2500000
            Console.WriteLine(ts1.ToString("d\\ hh\\-mm\\-ss")); // 5 10-15-20 , we have to use \\ as seprator

            // TryParse
            bool r1 = TimeSpan.TryParse("5.10:15:20.2500000", out TimeSpan result1);
            if(r1)
            {
                Console.WriteLine(result1); // 5.10:15:20.2500000
            }
            else
            {
                Console.WriteLine("Invalid TimeSpan format");
            }

            // TryParseExact
            bool r2 = TimeSpan.TryParseExact("5.10-15-20", "d\\.hh\\-mm\\-ss", CultureInfo.InvariantCulture, TimeSpanStyles.None, out TimeSpan result2);
            if(r2)
            {
                Console.WriteLine(result2); // 5.10:15:20
            }
            else
            {
                Console.WriteLine("Invalid TimeSpan format");
            }
        }
    }
}
