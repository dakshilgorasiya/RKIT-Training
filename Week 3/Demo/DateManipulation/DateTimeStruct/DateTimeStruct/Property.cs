using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeStruct
{
    internal class Property
    {
        static void Main(string[] args)
        {
            DateTime dt = new DateTime(2025, 10, 10, 15, 10, 15, 45);
            Console.WriteLine(dt); // 10/10/2025 3:10:15 pm

            // Get the date component with time set to 00:00:00
            Console.WriteLine(dt.Date); // 10/10/2025 12:00:00 am

            // Get the day of the month
            Console.WriteLine(dt.Day); // 10

            // Get the day of the week
            Console.WriteLine(dt.DayOfWeek); // Friday

            // Get the day of the year
            Console.WriteLine(dt.DayOfYear); // 283

            // Get the hour component
            Console.WriteLine(dt.Hour); // 15

            // Get the DateTimeKind (Local, Utc, Unspecified)
            Console.WriteLine(dt.Kind); // Unspecified

            // Get the microsecond component
            Console.WriteLine(dt.Microsecond); // 0

            // Get the millisecond component
            Console.WriteLine(dt.Millisecond); // 45

            //Get the minute component
            Console.WriteLine(dt.Minute); // 10

            //Get the month component
            Console.WriteLine(dt.Month); // 10

            // Get the nanosecond component
            Console.WriteLine(dt.Nanosecond); // 0

            // static
            // Get the current date and time
            Console.WriteLine(DateTime.Now); // 28/09/2025 1:16:09 pm

            // Get the seconds component
            Console.WriteLine(dt.Second); // 15

            // Get the ticks (100-nanosecond intervals since 0001-01-01 00:00:00)
            Console.WriteLine(dt.Ticks); // 638957058150450000

            // Get the time since the day midnight as a TimeSpan
            Console.WriteLine(dt.TimeOfDay); // 15:10:15.0450000

            // static
            // Get today's date with time set to 00:00:00
            Console.WriteLine(DateTime.Today); // 28/09/2025 12:00:00 am

            // static
            // Get the current date and time in UTC
            Console.WriteLine(DateTime.UtcNow); // 28/09/2025 7:49:37 am

            // Get the year component
            Console.WriteLine(dt.Year); // 2025
        }
    }
}
