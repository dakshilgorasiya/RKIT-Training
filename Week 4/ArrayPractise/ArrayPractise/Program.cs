using System.Security.Cryptography;

namespace ArrayPractise
{
    internal class Program
    {
        public class ReverseComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return y.CompareTo(x);
            }
        }
        static void Main(string[] args)
        {
            int[] arr = new int[] {1,2,3,4, 5, 6, 7, 8, 9, 10 };

            // Properties of Array
            Console.WriteLine("FixedSize : " + arr.IsFixedSize);
            Console.WriteLine("IsReadOnly : " + arr.IsReadOnly);
            Console.WriteLine("IsSynchronized : " + arr.IsSynchronized); // Thread Safe
            Console.WriteLine("Length : " + arr.Length);
            Console.WriteLine("LongLength : " + arr.LongLength);
            Console.WriteLine("Rank : " + arr.Rank); // Number of dimensions

            Console.WriteLine("\n\n");

            // Method
            Console.WriteLine("BinarySearch : " + Array.BinarySearch(arr, 5));
            //Array.Clear(arr, 0, arr.Length); // Clear all elements

            //Copy(sourceArray, sourseIndex, destinationArray, destinationIndex, length)
            // CopyTo(destinationArray, destinationIndex)

            // Exists
            //Console.WriteLine("Exists : " + Array.Exists(arr, element => element == 5));

            // Fill
            //Array.Fill(arr, 0); // Fill all elements with 0

            // Find
            Console.WriteLine("Find : " + Array.Find(arr, element => element > 5));
            // Also FindLast, FindAll, FindIndex, FindLastIndex

            Array.ForEach(arr, element => Console.Write(element + " ")); // ForEach

            Console.WriteLine("\n\n" + arr.GetLength(0)); // GetLength(dimension)

            // Give minimum and maximum index of the array at a particular dimension
            Console.WriteLine(arr.GetLowerBound(0) + " " + arr.GetUpperBound(0)); // GetLowerBound(dimension), GetUpperBound(dimension)

            Console.WriteLine("IndexOf : " + Array.IndexOf(arr, 5)); // IndexOf, LastIndexOf

            Array.Resize(ref arr, 20);
            Console.WriteLine("New Length : " + arr.Length); // Resize(ref array, newSize)

            //Array.Reverse(arr, 0, 10); // Reverse
            Array.ForEach(arr, element => Console.Write(element + " "));


            Console.WriteLine("\n\n");
            Console.WriteLine(Array.TrueForAll(arr, ele => ele >= 0)); // TrueForAll -> Check if all elements satisfy the condition

            Array.Resize(ref arr, 10);
            char[] val = new char[] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j'};

            for(int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
            Array.Sort(arr, new ReverseComparer());
            //Array.Sort(arr);

            for(int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}
