using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCollection
{
    internal class HashSetPractise
    {
        static void Main(string[] args)
        {
            // Constructor

            HashSet<int> hs1 = new HashSet<int>();

            int[] arr = new int[] { 1, 2, 3 };
            HashSet<int> hs2 = new HashSet<int>(arr);
            PrintHashSet(hs2);

            HashSet<int> hs3 = new HashSet<int> { 1, 2, 3 };
            PrintHashSet(hs3);




            // Prperty
            Console.WriteLine(hs2.Count);

            IEqualityComparer<int> comparer = hs2.Comparer;




            // Methods
            bool isAdded = hs2.Add(5); // arg1: T item // return true if element added successfully, false if already present

            hs1.Clear();

            Console.WriteLine(hs2.Contains(5)); // arg1: T item // true if present, false otherwise


            // CopyTo
            int[] arr1 = new int[5];
            hs2.CopyTo(arr1); // arg1: T[] array
            // other overload
            // array, arrayIndex
            // array, arrayIndex, count
            Console.WriteLine(String.Join(", ", arr1));

            
            IEqualityComparer<int> comparer1 = hs1.Comparer;

            hs1.EnsureCapacity(10); // Ensure minimum capacity

            hs2.ExceptWith(hs3);  // set except operation (-)
            PrintHashSet(hs2);

            hs2.IntersectWith(new int[] { 1, 5 }); // arg1: IEnumerable<T> // set intersection operation
            PrintHashSet(hs2);


            Console.WriteLine(hs2.IsProperSubsetOf(new int[] { 1, 5, 6 })); // arg1: IEnumerable<T> // true if current set is proper subset of arg1

            Console.WriteLine(hs2.IsProperSupersetOf(new int[] { 1 })); // arg1: IEnumerable<T> // true if current set is proper superset of arg1

            Console.WriteLine(hs2.IsSubsetOf(new int[] { 1, 5, 6 })); // arg1: IEnumerable<T> // true if current set is subset of arg1

            Console.WriteLine(hs2.IsSupersetOf(new int[] { 1 })); // arg1: IEnumerable<T> // true if current set is superset of arg1


            Console.WriteLine(hs2.Overlaps(new int[] { 1, 5 })); // arg1: IEnumerable<T> // true if the HashSet<T> object and other share at least one common element; otherwise, false.

            bool isRemoved = hs2.Remove(5); // arg1: T item // return true if element removed successfully, false if not found 
            PrintHashSet(hs2);

            //PrintHashSet(hs3);
            //hs3.RemoveWhere(ele => ele % 2 == 1); // arg1: Predicate<T> // remove all elements matching the condition defined by the specified predicate
            //PrintHashSet(hs3);

            Console.WriteLine(hs2.SetEquals(new int[] { 1 })); // arg1: IEnumerable<T> // set equality operation

            //PrintHashSet(hs3);
            //hs3.SymmetricExceptWith(new int[] { 1, 5 }); // arg1: IEnumerable<T> // set symmetric except operation A Δ B = (A - B) U (B - A)
            //PrintHashSet(hs3);

            hs3.TrimExcess(); // set the capacity to the actual number of elements if that number is less than 90 percent of current capacity still we can add more elements as it will increase the capacity automatically
            

            bool isFound = hs3.TryGetValue(2, out int value); // arg1: T equalValue, arg2: out T actualValue // return true if found otherwise false
            if(isFound)
            {
                Console.WriteLine(value);
            }

            PrintHashSet(hs3);
            hs3.UnionWith(new int[] { 5, 6 }); // arg1: IEnumerable<T> // set union operation (+)
            PrintHashSet(hs3);
        }
        static void PrintHashSet<T>(HashSet<T> hs)
        {
            foreach (T item in hs)
            {
                Console.Write(item);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}
