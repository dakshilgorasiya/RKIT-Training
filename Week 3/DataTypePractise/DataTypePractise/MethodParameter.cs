using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypePractise
{
    internal class MethodParameter
    {
        static void Main(string[] args)
        {
            int num = 5;
            Console.WriteLine("Before PassByValue: " + num); // Outputs 5
            PassByValue(num);
            Console.WriteLine("After PassByValue: " + num);  // Still outputs 5


            Console.WriteLine("Before PassByReference: " + num); // Outputs 5
            PassByReference(ref num);
            Console.WriteLine("After PassByReference: " + num);  // Outputs 15

            int a, b;
            //GetValues(out a, out b);
            GetValues(a: out a, b: out b); // Named arguments
            Console.WriteLine($"Output parameters: a = {a}, b = {b}"); // a = 1, b = 2

            OptionalParameter(5);        // y uses default value 10
            OptionalParameter(5, 15);    // y is explicitly set to 15

            NamedParameters(y: 20, x: 10); // Order doesn't matter
        }

        // Pass by value (default)
        static void PassByValue(int x)
        {
            x = x + 10;
        }

        // Pass by reference
        static void PassByReference(ref int x)
        {
            x = x + 10;
        }

        // Output parameter
        static void GetValues(out int a, out int b)
        {
            a = 1;
            b = 2;
        }

        // In parameter
        static void NamedParameters(in int x, in int y)
        {
            //x = x + 10; // Error: Cannot assign to 'x' because it is a readonly variable
            Console.WriteLine($"x: {x}, y: {y}");
        }

        // Optional parameter
        static void OptionalParameter(int x, int y = 10)
        {
            Console.WriteLine($"x: {x}, y: {y}");
        }
    }
}
