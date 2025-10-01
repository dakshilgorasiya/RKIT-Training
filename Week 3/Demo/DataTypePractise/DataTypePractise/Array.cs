using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypePractise
{
    internal class Array
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[2, 3];
            arr[1, 1] = 2;

            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);
            Console.WriteLine($"Rows: {rows}, Columns: {cols}");
            Console.WriteLine(arr[1, 1]); // Outputs 2
            foreach (int val in arr)
            {
                Console.Write(val + " ");  // Outputs 0 0 0 0 2 0
            }
            Console.WriteLine();


            int[][] jagged = new int[2][];
            jagged[0] = new int[] { 1, 2 };
            jagged[1] = new int[] { 3, 4, 5 };
            Console.WriteLine($"Jagged array first element length: {jagged[0].Length}, second element length: {jagged[1].Length}");
            Console.WriteLine(jagged[1][2]); // Outputs 5

            foreach (int[] row in jagged)
            {
                foreach (int val in row)
                {
                    Console.Write(val + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
