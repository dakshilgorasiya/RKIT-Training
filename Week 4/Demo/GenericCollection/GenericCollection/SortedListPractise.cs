using System.Collections.Generic;

namespace GenericCollection
{
    internal class SortedListPractise
    {
        static void Main(string[] args)
        {
            // Constructor
            SortedList<int, string> sl1 = new SortedList<int, string>();

            SortedList<string, string> sl2 = new SortedList<string, string>(StringComparer.OrdinalIgnoreCase); // arg1: IComparer<TKey> comparer

            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("1", "One");
            dict.Add("2", "Two");

            SortedList<string, string> sl3 = new SortedList<string, string>(dict); // arg1: IDictionary<TKey, TValue> dictionary

            SortedList<string, string> sl4 = new SortedList<string, string>(10); // arg1: int capacity

            SortedList<string, string> sl5 = new SortedList<string, string>(dict, StringComparer.OrdinalIgnoreCase); // arg1: IDictionary<TKey, TValue> dictionary, arg2: IComparer<TKey> comparer

            SortedList<string, string> sl6 = new SortedList<string, string>(10, StringComparer.OrdinalIgnoreCase); // arg1: int capacity, arg2: IComparer<TKey> comparer


            // Properties
            Console.WriteLine(sl4.Capacity); // get; set;

            IComparer<string> comparer = sl4.Comparer; // get;

            Console.WriteLine(sl3.Count); // get;

            Console.WriteLine(sl3["1"]); // get; set; arg: TKey key

            IList<string> keys = sl3.Keys; // get;

            IList<string> values = sl3.Values; // get;


            // Methods
            sl1.Add(1, "One"); // arg1: TKey key, arg2: TValue value // can throw ArgumentException if the key already exists in the SortedList

            //sl1.Clear(); // removes all elements from the SortedList

            bool containsKey = sl3.ContainsKey("1"); // arg: TKey key // returns true if the SortedList contains the specified key
            Console.WriteLine(containsKey);

            bool containsValue = sl3.ContainsValue("One"); // arg: TValue value // returns true if the SortedList contains the specified value

            Console.WriteLine(sl3.GetKeyAtIndex(1)); // arg: int index // returns the key at the specified index // can throw ArgumentOutOfRangeException if the index is less than 0 or greater than or equal to Count

            Console.WriteLine(sl3.GetValueAtIndex(0)); // arg: int index // returns the value at the specified index // can throw ArgumentOutOfRangeException if the index is less than 0 or greater than or equal to Count

            Console.WriteLine(sl3.IndexOfKey("2")); // arg: TKey key // returns the index of the specified key // returns -1 if the key is not found

            Console.WriteLine(sl3.IndexOfValue("Two")); // arg: TValue value // returns the index of the specified value // returns -1 if the value is not found

            //bool removed = sl3.Remove("1"); // arg: TKey key // removes the element with the specified key // returns true if the element is successfully found and removed

            //sl3.RemoveAt(0); // arg: int index // removes the element at the specified index // can throw ArgumentOutOfRangeException if the index is less than 0 or greater than or equal to Count

            sl3.SetValueAtIndex(1, "Two Updated"); // arg1: int index, arg2: TValue value // sets the value at the specified index // can throw ArgumentOutOfRangeException if the index is less than 0 or greater than or equal to Count

            sl3.TrimExcess(); // sets the capacity to the actual number of elements in the SortedList, if that number is less than 90 percent of current capacity

            bool found = sl3.TryGetValue("2", out string? value); // arg1: TKey key, arg2: out TValue value // returns true if the key was found, otherwise false

            if(found)
            {
                Console.WriteLine(value);
            }
        }
    }
}
