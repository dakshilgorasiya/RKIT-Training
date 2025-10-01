using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringClass
{
    internal class Operator
    {
        static void Main(string[] args)
        {
            String s1 = "Hello";
            String s2 = "World";

            Console.WriteLine(s1 == s2);
            Console.WriteLine(s1 != s2);
            Console.WriteLine(s1 + " " + s2);
            
            ReadOnlySpan<char> span1 = s1;
            Console.WriteLine(span1.ToString());
        }
    }
}
