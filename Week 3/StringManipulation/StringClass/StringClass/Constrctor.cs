using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringClass
{
    internal class Constrctor
    {
        static void Main(string[] args)
        {
            String s1 = new String("Hello World".ToCharArray());
            Console.WriteLine(s1);

            ReadOnlySpan<char> span = "Hello World".AsSpan();
            String s2 = new String(span);
            Console.WriteLine(s2);

            String s3 = new String('*', 10);
            Console.WriteLine(s3);

            String s4 = new String(new char[] { 'H', 'e', 'l', 'l', 'o' }, 1, 3);
            Console.WriteLine(s4);


        }
    }
}
