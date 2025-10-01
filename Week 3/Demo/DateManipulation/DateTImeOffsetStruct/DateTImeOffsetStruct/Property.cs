using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTImeOffsetStruct
{
    internal class Property
    {
        static void Main(string[] args)
        {
            DateTimeOffset dtf = new DateTimeOffset(2025, 9, 28, 15, 54, 51, new TimeSpan(5, 30, 0));
            Console.WriteLine(dtf); // 28/09/2025 3:54:51 pm +05:30

            Console.WriteLine(dtf.Date); // 28/09/2025 12:00:00 am

            Console.WriteLine(dtf.DateTime); // 28/09/2025 3:54:51 pm

            Console.WriteLine(dtf.Day); // 28

            Console.WriteLine(dtf.DayOfWeek); // Sunday

            Console.WriteLine(dtf.DayOfYear); // 271

            Console.WriteLine(dtf.Hour); // 15

            Console.WriteLine(dtf.LocalDateTime); // 28/09/2025 3:54:51 pm

            Console.WriteLine(dtf.UtcDateTime); // 28/09/2025 10:24:51 am

            Console.WriteLine(dtf.Microsecond); // 0

            Console.WriteLine(dtf.Millisecond); // 0

            Console.WriteLine(dtf.Minute); // 54

            Console.WriteLine(dtf.Month); // 9

            Console.WriteLine(dtf.Nanosecond); // 0

            Console.WriteLine(DateTimeOffset.Now); // 28/09/2025 4:09:44 pm +05:30

            Console.WriteLine(DateTimeOffset.UtcNow); // 28/09/2025 10:39:44 am +00:00

            Console.WriteLine(dtf.Offset); // 05:30:00

            Console.WriteLine(dtf.Second); // 51

            Console.WriteLine(dtf.Ticks); // 638946716910000000

            Console.WriteLine(dtf.UtcTicks); // 638946518910000000

            Console.WriteLine(dtf.TimeOfDay); // 15:54:51

            Console.WriteLine(dtf.TotalOffsetMinutes); // 330

            Console.WriteLine(dtf.Year); // 2025
        }
    }
}
