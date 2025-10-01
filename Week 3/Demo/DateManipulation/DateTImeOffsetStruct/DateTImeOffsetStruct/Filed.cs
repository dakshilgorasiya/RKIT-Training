using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTImeOffsetStruct
{
    internal class Filed
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTimeOffset.MinValue); // 01/01/0001 12:00:00 am +00:00
            
            Console.WriteLine(DateTimeOffset.MaxValue); // 31/12/9999 11:59:59 pm +00:00

            Console.WriteLine(DateTimeOffset.UnixEpoch); // 01/01/1970 12:00:00 am +00:00
        }
    }
}
