using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSpanStruct
{
    internal class Constructor
    {
        static void Main(string[] args)
        {
            TimeSpan ts1 = new TimeSpan(549846519865); // arg1(long) ticks
            Console.WriteLine(ts1); // 15:16:24.6519865

            TimeSpan ts2 = new TimeSpan(12, 30, 45); // arg1(int) hours, arg2(int) minutes, arg3(int) seconds
            Console.WriteLine(ts2); // 12:30:45

            TimeSpan ts3 = new TimeSpan(10, 20, 30, 40); // arg1(int) days, arg2(int) hours, arg3(int) minutes, arg4(int) seconds
            Console.WriteLine(ts3); // 10.20:30:40

            TimeSpan ts4 = new TimeSpan(5, 10, 15, 20, 250); // arg1(int) days, arg2(int) hours, arg3(int) minutes, arg4(int) seconds, arg5(int) milliseconds
            Console.WriteLine(ts4); // 5.10:15:20.2500000

            TimeSpan ts5 = new TimeSpan(5, 10, 15, 20, 250, 500); // arg1(int) days, arg2(int) hours, arg3(int) minutes, arg4(int) seconds, arg5(int) milliseconds, arg6(int) microseconds
            Console.WriteLine(ts5); // 5.10:15:20.2505000

            TimeSpan ts6 = new TimeSpan();
            Console.WriteLine(ts6); // 00:00:00
        }
    }
}
