using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCollection
{
    static class DictionaryExtension
    {
        public static void PrintAll<TKey, TValue>(this Dictionary<TKey, TValue> dict)
        {
            foreach (KeyValuePair<TKey, TValue> item in dict)
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }
            Console.WriteLine();
        }
    }
    internal class DictionaryPractise
    {
        static void Main(string[] args)
        {
            // Constructors

            Dictionary<int, string> d1 = new ();

            Dictionary<int, string> d2 = new (d1); // arg1: IDictionary<TKey,TValue>

            List<KeyValuePair<int, string>> lst = new List<KeyValuePair<int, string>>();
            lst.Add(new KeyValuePair<int, string>(1, "One"));
            lst.Add(new KeyValuePair<int, string>(2, "Two"));

            Dictionary<string, string> d3 = new(StringComparer.OrdinalIgnoreCase); // arg1: IEqualityComparer<TKey> comparer

            Dictionary<int, string> d4 = new (lst); // arg1: IEnumerable<KeyValuePair<TKey,TValue>>
            d4.PrintAll();

            Dictionary<string, string> d5 = new(d3, StringComparer.OrdinalIgnoreCase); // arg1: IDictionary<TKey,TValue> dictionary, arg2: IEqualityComparer<TKey> comparer

            // Other
            // IEnumerable<KeyValuePair<TKey,TValue>>, IEqualityComparer<TKey>
            // capacity, IEqualityComparer<TKey>



            // Properties
            IEqualityComparer<string> comparer = d3.Comparer; // get;
            Console.WriteLine(comparer.Equals("hello", "HELLO")); // True

            Console.WriteLine(d4.Count); // get;

            d4[4] = "Four"; // get; set;
            Console.WriteLine(d4[4]); // Four

            foreach(int key in d4.Keys) // get;
            {
                Console.WriteLine(key);
            }

            foreach(string value in d4.Values) // get;
            {
                Console.WriteLine(value);
            }




            // Methods
            Console.WriteLine();
            d4.PrintAll();
            d4.Add(5, "Five"); // arg1: TKey key, arg2: TValue value // can throw ArgumentException if the key already exists in the Dictionary
            d4.PrintAll();

            d1.Clear();

            Console.WriteLine(d4.ContainsKey(2)); // arg1: TKey key // Returns true if the Dictionary contains an element with the specified key.

            Console.WriteLine(d4.ContainsValue("Two")); // arg1: TValue value // Returns true if the Dictionary contains an element with the specified value.

            // Can be used for optimization
            Console.WriteLine(d4.EnsureCapacity(20)); // arg1: int capacity // Returns the new capacity of the Dictionary, or the existing capacity if it is already >= capacity.

            bool isDeletd = d4.Remove(5); // arg1: TKey key // Returns true if the element is successfully found and removed; otherwise, false.

            bool isDeleted2 = d4.Remove(4, out string? val); // arg1: TKey key, arg2: out TValue value // Returns true if the element is successfully found and removed; otherwise, false. If found value is assigned to out parameter.
            if(isDeleted2)
            {
                Console.WriteLine($"Deleted value: {val}");
            }

            // Can reduce memory overhead
            d4.TrimExcess(10); // arg1: int capacity // Sets the capacity // Throws ArgumentOutOfRangeException if capacity is less than Count.

            d4.TrimExcess(); // Sets the capacity of this dictionary to what it would be if it had been originally initialized with all its entries.

            

            bool isAdded = d4.TryAdd(5, "Five"); // arg1: TKey key, arg2: TValue value // Returns true if the key/value pair was added to the Dictionary successfully. If the key already exists, this method returns false.
            d4.PrintAll();


            bool isFound = d4.TryGetValue(2, out string? value2); // arg1: TKey key, arg2: out TValue value // Returns true if the key was found. If found, value contains the value associated with the specified key.
            if(isFound)
            {
                Console.WriteLine(value2);
            }


        }
    }
}
