using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtherPractise
{
    internal class YieldPractise
    {
        static IEnumerable<int> GetNumbers()
        {
            Console.WriteLine("Start");

            yield return 1;

            Console.WriteLine("After 1");

            yield return 2;

            Console.WriteLine("After 2");

            yield return 3;

            Console.WriteLine("After 3");

            yield break;

            Console.WriteLine("After break");

            yield return 4;
        }
        static void Main(string[] args)
        {
            IEnumerable<int> numbers = GetNumbers();

            foreach (int item in numbers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
