using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCollection
{
    static class HashTableExtensions
    {
        public static void Display(this Hashtable ht)
        {
            foreach (DictionaryEntry entry in ht)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
            Console.WriteLine();
        }
    }
    internal class HashTablePractise
    {
        static void Main(string[] args)
        {
            // Constructors

            Hashtable ht1 = new Hashtable();

            Hashtable ht2 = new(20, 0.5f, StringComparer.OrdinalIgnoreCase); // arg1: int capacity, arg2: float loadFactor(how much table is filled before resizing), arg3: IEqualityComparer comparer

            Dictionary<string, string> dict = new();

            Hashtable hs3 = new(dict, 0.5f, StringComparer.OrdinalIgnoreCase); // arg1: IDictionary dictionary, arg2: float loadFactor, arg3: IEqualityComparer comparer


            Hashtable ht4 = new(10, 0.5f); // arg1: int capacity, arg2: float loadFactor

            Hashtable ht5 = new(dict, 0.5f); // arg1: IDictionary dictionary, arg2: float loadFactor

            Hashtable ht6 = new(dict, StringComparer.OrdinalIgnoreCase); // arg1: IDictionary dictionary, arg2: IEqualityComparer comparer

            Hashtable ht7 = new(50); // arg1: int capacity

            Hashtable ht8 = new(StringComparer.OrdinalIgnoreCase); // arg1: IEqualityComparer comparer

            Hashtable ht9 = new(dict); // arg1: IDictionary dictionary

            Hashtable ht10 = new(dict, StringComparer.OrdinalIgnoreCase); // arg1: IDictionary dictionary, arg2: IEqualityComparer comparer




            // Properties
            Console.WriteLine(ht4.Count); // get;

            Console.WriteLine(ht4.IsFixedSize); // get;

            Console.WriteLine(ht4.IsReadOnly); // get;

            Console.WriteLine(ht5.IsSynchronized); // get;

            ht4[1] = "One"; // get; set;
            Console.WriteLine(ht4[1]);

            foreach(object key in ht4.Keys) // get;
            {
                Console.WriteLine(key);
            }

            foreach(object value in ht4.Values) // get;
            {
                Console.WriteLine(value);
            }



            // Methods
            ht4.Add(2, "Two"); // arg1: object key, arg2: object value
            ht4.Add(3, "Three");
            ht4.Display();

            ht1.Clear();

            // Shallow copy
            Hashtable htClone = (Hashtable)ht4.Clone(); // Returns a shallow copy of the Hashtable.


            bool containsKey = ht4.Contains(2); // arg1: object key // Returns true if the Hashtable contains an element with the specified key.
            Console.WriteLine(containsKey);

            bool containsKey1 = ht4.ContainsKey(2); // arg1: object key // Returns true if the Hashtable contains an element with the specified key.
            Console.WriteLine(containsKey1);

            bool containsValue = ht4.ContainsValue("Two"); // arg1: object value // Returns true if the Hashtable contains an element with the specified value.
            Console.WriteLine(containsValue);


            DictionaryEntry[] arr = new DictionaryEntry[ht4.Count];
            ht4.CopyTo(arr, 0); // arg1: Array array, arg2: int index // Copies the elements of the Hashtable to a one-dimensional Array, starting at the specified index of the target array.
            foreach(DictionaryEntry entry in arr)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }

            ht4.Display();
            ht4.Remove(2);
            ht4.Display();


            Hashtable synchonizedHT = Hashtable.Synchronized(ht4); // arg1: Hashtable table // Returns a synchronized (thread-safe) wrapper for the Hashtable.
        }
    }
}
