using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace DateTimeStruct
{
    internal class Method
    {
        static void Main(string[] args)
        {
            TimeSpan duration = new TimeSpan(5, 30, 0); // 5 hours, 30 minutes, 0 seconds

            DateTime dt = new DateTime(2025, 10, 10, 15, 10, 15, 45); // 10/10/2025 3:10:15 pm
            DateTime dt2 = new DateTime(2023, 5, 5, 10, 5, 5, 25); // 05/05/2023 10:05:05 am

            // Add duration to DateTime
            Console.WriteLine(dt.Add(duration)); // 10/10/2025 8:40:15 pm

            // Add days
            Console.WriteLine(dt.AddDays(5)); // 15/10/2025 3:10:15 pm

            // Add hours
            Console.WriteLine(dt.AddHours(3)); // 10/10/2025 6:10:15 pm

            // other
            // AddMicroseconds, AddMilliseconds, AddMinutes, AddMonths, AddNanoseconds, AddSeconds, AddTicks, AddYears

            // Compare
            // less than 0 -> dt is earlier than dt2
            // 0 -> dt is the same as dt2
            // greater than 0 -> dt is later than dt2
            Console.WriteLine(DateTime.Compare(dt, dt2)); // 1 -> dt is later than dt2

            // ComapreTo two overloads
            Console.WriteLine(dt.CompareTo(dt2)); // 1 -> dt is later than dt2
            Console.WriteLine(dt2.CompareTo((object)dt)); // -1 -> dt2 is earlier than dt

            // Give days in month
            Console.WriteLine(DateTime.DaysInMonth(2024, 2)); // 29 -> 2024 is a leap year

            // Deconstruct two overloads
            dt.Deconstruct(out int year, out int month, out int day);
            Console.WriteLine($"{year}-{month}-{day}"); // 2025-10-10
            dt.Deconstruct(out DateOnly dateOnly, out TimeOnly timeOnly);
            Console.WriteLine($"{dateOnly} {timeOnly}"); // 10/10/2025 3:10 pm

            // Equals three overloads
            Console.WriteLine(dt.Equals(dt2)); // False
            Console.WriteLine(dt.Equals((object)dt2)); // False
            Console.WriteLine(DateTime.Equals(dt, dt2)); // False

            // From Binary
            // 64 bit, 2 bit kind and 62 bit ticks
            Console.WriteLine(DateTime.FromBinary(dt.ToBinary())); // 10/10/2025 3:10:15 pm
            Console.WriteLine(dt.ToBinary()); // 638957058150450000

            // FromFileTime
            Console.WriteLine(DateTime.FromFileTime(dt.ToFileTime())); // 10/10/2025 3:10:15 pm

            // FromFileTimeUtc
            Console.WriteLine(DateTime.FromFileTimeUtc(dt.ToFileTimeUtc())); // 10/10/2025 3:10:15 pm

            // GetDateTimeFormats 
            // Give all possible string formats
            //foreach (var format in dt.GetDateTimeFormats())
            //{
            //    Console.WriteLine(format);
            //}     
            //foreach(var format in dt.GetDateTimeFormats('d')) // short date pattern
            //{
            //    Console.WriteLine(format);
            //}
            //foreach (var format in dt.GetDateTimeFormats(new CultureInfo("in-IN", true)))
            //{
            //    Console.WriteLine(format);
            //}
            //foreach (var format in dt.GetDateTimeFormats('d', new CultureInfo("in-IN", true)))
            //{
            //    Console.WriteLine(format);
            //}

            // GetHashCode
            Console.WriteLine(dt.GetHashCode()); // 353848159

            // GetTypeCode
            Console.WriteLine(dt.GetTypeCode()); // DateTime

            // IsLeapYear
            Console.WriteLine(DateTime.IsLeapYear(2024)); // True

            // Parse
            // string, IFormatProvider, DateTimeStyles
            Console.WriteLine(DateTime.Parse("2025-10-10T15:10:15.0450000", CultureInfo.CreateSpecificCulture("en-US"), DateTimeStyles.AllowLeadingWhite)); // 10/10/2025 3:10:15 pm
            // other
            // string
            // string, IFormatProvider
            // string, DateTimeStyles
            // string, IFormatProvider, DateTimeStyles

            // Subtract two overloads
            Console.WriteLine(dt.Subtract(dt2)); // 889.05:05:10.0200000
            Console.WriteLine(dt.Subtract(duration)); // 10/10/2025 9:40:15 am

            // ToFileTime
            // 64 bit, 2 bit kind and 62 bit ticks since 1601-01-01 00:00:00 in 100 ns intervals
            Console.WriteLine(dt.ToFileTime()); // 133456789345678900
            // ToFileTimeUtc

            // ToLocalTime
            Console.WriteLine(dt.ToLocalTime()); // 10/10/2025 8:40:15 pm -> dt + 5:30 (IST)

            // ToLongDateString
            Console.WriteLine(dt.ToLongDateString()); // Friday, 10 October 2025

            // ToLongTimeString
            Console.WriteLine(dt.ToLongTimeString()); // 3:10:15 pm

            // OLE automation date
            // the number of days before or after midnight, 30 December 1899, and whose fractional component represents the time on that day divided by 24.
            Console.WriteLine(dt.ToOADate()); // 45940.63211857639

            // ToShortDateString
            Console.WriteLine(dt.ToShortDateString()); // 10/10/2025

            // ToShortTimeString
            Console.WriteLine(dt.ToShortTimeString()); // 3:10 pm

            // ToString
            Console.WriteLine(dt.ToString()); // 10/10/2025 3:10:15 pm
            Console.WriteLine(dt.ToString("yyyy-MM-dd HH:mm:ss")); // 2025-10-10 15:10:15
            Console.WriteLine(dt.ToString(new CultureInfo("in-IN", true))); // 10/10/2025 3:10:15 pm
            Console.WriteLine(dt.ToString("yyyy-MM-dd", new CultureInfo("in-IN", true))); // 2025-10-10

            // ToUniversalTime
            Console.WriteLine(dt.ToUniversalTime()); // 10/10/2025 9:40:15 am -> dt - 5:30 (IST)

            // TryParse
            bool r1 = DateTime.TryParse("2025-10/10 15:10:15.0450000", out DateTime result1);
            if(r1)
            {
                Console.WriteLine(result1); // 10/10/2025 3:10:15 pm
            }
            else
            {
                Console.WriteLine("Invalid DateTime string");
            }

            // TryParseExact
            bool r2 = DateTime.TryParseExact("2025/10/10 15:10:15", "yyyy/MM/dd HH:mm:ss", CultureInfo.CreateSpecificCulture("en-US"), DateTimeStyles.AssumeLocal, out DateTime result2);
            if(r2)
            {
                Console.WriteLine(result2);
            }
            else
            {
                Console.WriteLine("String not in the correct format");
            }
        }
    }
}
