using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBuilderClass
{
    internal class Property
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder("Hello, World!", 50);
            Console.WriteLine("Capacity: " + sb.Capacity); // Capacity: 50
            Console.WriteLine("Length: " + sb.Length); // Length: 13
            Console.WriteLine("MaxCapacity: " + sb.MaxCapacity); // MaxCapacity: 2147483647
            Console.WriteLine("Chars at index 0: " + sb[0]); // Chars at index 0: H
            sb[0] = 'h';
            Console.WriteLine("Chars at index 0 after modification: " + sb[0]); // Chars at index 0 after modification: h
        }
    }
}
