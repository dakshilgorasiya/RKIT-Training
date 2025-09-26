using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypePractise
{
    internal class Loop
    {
        static void Main(string[]args)
        {
            Console.WriteLine("For loop");
            for (int i = 1; i <= 10; i++)
            {
                Console.Write(i + " ");
            }
            
            Console.WriteLine("\nForeach loop");
            string[] names = { "Alice", "Bob", "Charlie" };
            foreach (string name in names)
            {
                Console.Write(name + " ");
            }

            Console.WriteLine("\nParallel loop"); // Useful for CPU-bound operations which can be parallelized
            Parallel.For(1, 11, i =>
            {
                Console.Write(i + " ");
            });
        }
    }
}
