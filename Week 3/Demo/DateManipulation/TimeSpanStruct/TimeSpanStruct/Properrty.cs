using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSpanStruct
{
    internal class Properrty
    {
        static void Main(string[] args)
        {
            TimeSpan ts = new TimeSpan(5, 10, 15, 20, 250); // 5 days, 10 hours, 15 minutes, 20 seconds, 250 milliseconds
            Console.WriteLine(ts.Days); // 5
            Console.WriteLine(ts.Hours); // 10
            Console.WriteLine(ts.Microseconds); // 0
            Console.WriteLine(ts.Milliseconds); // 250
            Console.WriteLine(ts.Minutes); // 15
            Console.WriteLine(ts.Nanoseconds); // 0
            Console.WriteLine(ts.Seconds); // 20
            Console.WriteLine(ts.Ticks); // 4689202500000
            Console.WriteLine(ts.TotalDays); // 5.427317708333334
            Console.WriteLine(ts.TotalHours); // 130.255625
            Console.WriteLine(ts.TotalMicroseconds); // 468920250000
            Console.WriteLine(ts.TotalMilliseconds); // 468920250
            Console.WriteLine(ts.TotalMinutes); // 7815.3375
            Console.WriteLine(ts.TotalNanoseconds); // 468920250000000
            Console.WriteLine(ts.TotalSeconds); // 468920.25
        }
    }
}
