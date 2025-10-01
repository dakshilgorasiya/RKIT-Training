using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTImeOffsetStruct
{
    internal class Constructor
    {
        static void Main(string[] args)
        {
            DateTimeOffset dtf1 = new DateTimeOffset();
            Console.WriteLine(dtf1); // 01/01/0001 12:00:00 am +00:00

            DateTimeOffset dtf2 = new DateTimeOffset(DateTime.Now); // arg1(DateTime dateTime)
            Console.WriteLine(dtf2); // 28/09/2025 3:54:51 pm +05:30

            DateTime dt = new DateTime(2025, 9, 28, 15, 54, 51);
            TimeSpan ts = new TimeSpan(5, 30, 0);

            DateTimeOffset dtf3 = new DateTimeOffset(dt, ts); // arg1(DateTime dateTime), arg2(TimeSpan offset)
            Console.WriteLine(dtf3); // 28/09/2025 3:54:51 pm +05:30

            DateTimeOffset dtf4 = new DateTimeOffset(658456548965, ts); // arg1(long ticks), arg2(TimeSpan offset)
            Console.WriteLine(dtf4); // 01/01/0001 6:17:25 pm +05:30

            DateOnly dateOnly = new DateOnly(2025, 9, 28);
            TimeOnly timeOnly = new TimeOnly(15, 54, 51);
            DateTimeOffset dtf5 = new DateTimeOffset(dateOnly, timeOnly, ts); // arg1(DateOnly date), arg2(TimeOnly time), arg3(TimeSpan offset)
            Console.WriteLine(dtf5); // 28/09/2025 3:54:51 pm +05:30

            DateTimeOffset dtf6 = new DateTimeOffset(2025, 9, 28, 15, 54, 51, ts); // arg1(int year), arg2(int month), arg3(int day), arg4(int hour), arg5(int minute), arg6(int second), arg7(TimeSpan offset)
            Console.WriteLine(dtf6); // 28/09/2025 3:54:51 pm +05:30

            // other
            // year, month, day, hour, minute, second, millisecond, offset
            // year, month, dat, hour, minute, second, millisecond, calendar, offset
            // year, month, day, hour, minute, second, millisecond, microsecond, offset
            // year, month, day, hour, minute, second, millisecond, microsecond, calender, offset
        }
    }
}
