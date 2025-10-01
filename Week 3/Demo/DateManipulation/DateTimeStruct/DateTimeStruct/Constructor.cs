using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace DateTimeStruct
{
    internal class Constructor
    {
        static void Main(string[] args)
        {
            DateTime dt1 = new DateTime(15065651651); // arg1(long) ticks since 0001-01-01 00:00:00 in 100 ns intervals
            Console.WriteLine(dt1); // 01/01/0001 12:25:06 am


            DateTime dt2 = new DateTime(2025, 10, 10, 15, 10, 15, 45, 150, new GregorianCalendar()); // arg1(int) year, arg2(int) month, arg3(int) day, arg4(int) hour, arg5(int) minute, arg6(int) second, arg7(int) millisecond, arg8(int) microsecond, arg9(Calendar) calendar
            Console.WriteLine(dt2); // 10/10/2025 3:10:15 pm

            DateTime dt3 = new DateTime(2025, 12, 10, 12, 50, 23, 150, 150, DateTimeKind.Utc); // arg1(int) year, arg2(int) month, arg3(int) day, arg4(int) hour, arg5(int) minute, arg6(int) second, arg7(int) millisecond, arg8(int) microsecond, arg9(DateTimeKind) kind
            Console.WriteLine(dt3); // 10/12/2025 12:50:23 pm

            DateTime dt4 = new DateTime(2025, 10, 15, 23, 15, 45, 78, new GregorianCalendar(), DateTimeKind.Local); // arg1(int) year, arg2(int) month, arg3(int) day, arg4(int) hour, arg5(int) minute, arg6(int) second, arg7(int) millisecond, arg8(Calendar) calendar, arg9(DateTimeKind) kind
            Console.WriteLine(dt4); // 15/10/2025 11:15:45 pm

            // use gregorian calendar
            DateTime dt5 = new DateTime(2030, 11, 30, 11, 15, 30, 45, 15); // arg1(int) year, arg2(int) month, arg3(int) day, arg4(int) hour, arg5(int) minute, arg6(int) second, arg7(int) millisecond, arg8(int) microsecond
            Console.WriteLine(dt5); // 31/11/2030 11:15:30 am

            // If kind is not given It will take DateTimeKind.Unspecified as default value In which time is not specified as local time or UTC time
            // when we call toLocalTime() it will assume that the time is UTC time and convert it to local time
            // when we call toUniversalTime() it will assume that the time is local time and convert it to UTC time
            DateTime dt6 = new DateTime(2025, 10, 10, 15, 20, 50, DateTimeKind.Unspecified); // arg1(int) year, arg2(int) month, arg3(int) day, arg4(int) hour, arg5(int) minute, arg6(int) second, arg7(DateTimeKind) kind
            Console.WriteLine(dt6.ToLocalTime()); // 10/10/2025 8:50:50 pm ->  dt6 + 5:30 (IST)
            Console.WriteLine(dt6.ToUniversalTime()); // 10/10/2025 9:50:50 am -> dt6 - 5:30 (IST)
            Console.WriteLine(dt6); // 10/10/2025 3:20:50 pm


            // other
            // year, month, day, hour, minute, second, millisecond, calender
            // year, month, day, hour, minute, second, millisecond, kind
            // year, month, day, hour, minute, second, millisecond
            // year, month, day, hour, minute, second, millisecond, microsecond, calendar, kind
            // year, month, day, hour, minute, second, kind
            // year, month, day, hour, minute, second
            // year, month, dat, calendar,
            // year, month, day
            // year, month, day, hour, minute, second, calender

            DateOnly dateOnly = new DateOnly(2025, 10, 10); // arg1(int) year, arg2(int) month, arg3(int) day
            TimeOnly timeOnly = new TimeOnly(15, 10, 10, 150); // arg1(int) hour, arg2(int) minute, arg3(int) second, arg4(int) millisecond
            DateTime dt7 = new DateTime(dateOnly, timeOnly, DateTimeKind.Utc); // arg1(DateOnly) date, arg2(TimeOnly) time, arg3(DateTimeKind) kind
            Console.WriteLine(dt7); // 10/10/2025 3:10:10 pm


            DateTime dt8 = new DateTime(10546414561, DateTimeKind.Utc); // arg1(long) ticks since 0001-01-01 00:00:00 in 100 ns intervals, arg2(DateTimeKind) kind
            Console.WriteLine(dt8); // 01/01/0001 12:17:34 am

            DateTime dt9 = new DateTime(dateOnly, timeOnly); // arg1(DateOnly) date, arg2(TimeOnly) time
            Console.WriteLine(dt9); // 10/10/2025 3:10:10 pm

            DateTime dt10 = new DateTime(); // default constructor
            Console.WriteLine(dt10); // 01/01/0001 12:00:00 am

        }
    }
}
