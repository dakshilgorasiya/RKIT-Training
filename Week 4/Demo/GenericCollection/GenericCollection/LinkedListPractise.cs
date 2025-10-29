using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCollection
{
    internal class LinkedListPractise
    {
        static void Main(string[] args)
        {
            // Constructor

            LinkedList<int> ll1 = new LinkedList<int>();

            int[] vals = new int[] { 1, 2, 3, 4 };
            LinkedList<int> ll2 = new LinkedList<int>(vals); // arg: IEnumerable<T> Intialize list as given list

            // Property
            Console.WriteLine(ll2.Count);

            LinkedListNode<int> first = ll2.First;
            Console.WriteLine(first.Value);
            Console.WriteLine(first.Next.Value);

            LinkedListNode<int> last = ll2.Last;
            Console.WriteLine(last.Value);
            Console.WriteLine(last.Previous.Value);


            // Methods
            PrintLinkList<int>(ll2);

            // AddAfter
            //ll2.AddAfter(first, new LinkedListNode<int>(5));
            ll2.AddAfter(first, 5);
            PrintLinkList(ll2);
            // Also have AddBefore
            // AddFirst, AddLast take only one parameter

            //ll2.Clear();

            Console.WriteLine(ll2.Contains(5));


            // CopyTo
            int[] arr = new int[10];
            ll2.CopyTo(arr, 1); // arg1: T[] array, arg2: int startindex for array
            Console.WriteLine(String.Join(", ", arr));

            // Find and FindLast
            LinkedListNode<int> f = ll2.Find(4);
            if(f != null)
            {
                Console.WriteLine(f.Value);
            }

            ll2.Remove(5); // Overload: LinkListNode<T>
            PrintLinkList(ll2);

            // RemoveFirst, RemoveLast
        }
        static void PrintLinkList<T>(LinkedList<T> ll)
        {
            foreach (T item in ll)
            {
                Console.Write(item);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}
