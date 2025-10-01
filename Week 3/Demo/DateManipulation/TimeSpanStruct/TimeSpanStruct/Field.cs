using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSpanStruct
{
    internal class Field
    {
        static void Main(string[] args)
        {
            TimeSpan ts = new TimeSpan(5, 10, 15, 20, 250); // 5 days, 10 hours, 15 minutes, 20 seconds, 250 milliseconds

            Console.WriteLine(TimeSpan.MaxValue); // 10675199.02:48:05.4775807

            Console.WriteLine(TimeSpan.MinValue); // -10675199.02:48:05.4775808

            Console.WriteLine(TimeSpan.NanosecondsPerTick); // 100

            Console.WriteLine(TimeSpan.TicksPerDay); // 864000000000

            Console.WriteLine(TimeSpan.TicksPerHour); // 36000000000

            Console.WriteLine(TimeSpan.TicksPerMicrosecond); // 10

            Console.WriteLine(TimeSpan.TicksPerMillisecond); // 10000

            Console.WriteLine(TimeSpan.TicksPerMinute); // 600000000

            Console.WriteLine(TimeSpan.TicksPerSecond); // 10000000

            Console.WriteLine(TimeSpan.Zero); // 00:00:00
        }
    }
}
