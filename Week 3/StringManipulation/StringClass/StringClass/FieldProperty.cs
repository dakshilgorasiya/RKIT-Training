using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringClass
{
    internal class FieldProperty
    {
        static void Main(string[] args)
        {
            // Field
            // Give empty string
            Console.WriteLine(String.Empty);

            String s = "HELLO WORLD";

            // Property
            Console.WriteLine(s[2]);
            Console.WriteLine(s.Length);
        }
    }
}
