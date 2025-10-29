using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCollection
{
    public static class ArrayListExtension
    {
        public static void Print(this ArrayList al)
        {
            foreach (var item in al)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
    internal class ArrayListPractise
    {
        static void Main(string[] args)
        {
            // Constructor

            ArrayList al1 = new ArrayList();

            ArrayList al2 = new ArrayList(10); // initial capacity

            ArrayList al3 = new ArrayList(new int[] { 1, 2, 3 });
            al3.Print();


            // Property
            Console.WriteLine(al3.Count); // get; set;
            Console.WriteLine(al3.Capacity); // get;
            Console.WriteLine(al3.IsFixedSize); // get;
            Console.WriteLine(al3.IsReadOnly); // get;
            Console.WriteLine(al3.IsSynchronized); // get;

            Console.WriteLine(al3[1]); // get; set; arg: int index



            // Methods

            // Adapter -> Creates a wraper around IList
            ArrayList il = ArrayList.Adapter(new int[] { 1, 2, 3 });
            il.Print();

            int index1 = al3.Add(4); // arg1: object value // return index at which value is added
            al3.Print();
            Console.WriteLine(index1);


            al3.AddRange(new int[] { -1, 2, 5 }); // arg1: ICollection c
            al3.Print();

            al3.Sort(); // Sorts the ArrayList
            // Other overloads
            // IComparer
            // startIndex, count, IComparer

            al3.Print();

            int index2 = al3.BinarySearch(2); // arg1: object value // returns index of the value if found, otherwise negative number
            // Other overloads
            // value, IComparer
            // startIndex, count, value, IComparer

            Console.WriteLine(index2);


            //al3.Clear(); // removes all elements
            //ArrayList al4 = (ArrayList)al3.Clone(); // returns a shallow copy of the ArrayList


            // Linear search
            Console.WriteLine(al3.Contains(5)); // arg1: object value // returns true if value is found, otherwise false


            // CopyTo
            int[] arr = new int[10];
            al3.CopyTo(arr); // arg1: Array array
            // other overloads
            // array, arrayIndex (destination index)
            // sourceIndex, array, destination index, count
            Console.WriteLine(String.Join(", ", arr));


            // FixedSize
            ArrayList al5 = ArrayList.FixedSize(al3);
            // al5.Add(10); // NotSupportedException
             //al5.RemoveAt(0); // NotSupportedException
            // al5.Clear(); // NotSupportedException
             al5[0] = 10; // Supported


            ArrayList al6 = al3.GetRange(2, 4); // arg1: int index, arg2: int count
            al6.Print();


            Console.WriteLine(al3.IndexOf(2)); // arg1: object value // returns index of the value if found, otherwise -1
            // Other overloads
            // value, startIndex
            // value, startIndex, count
            // LastIndexOf has same overloads but searches from end to start

            al3.Insert(0, -10); // arg1: int index, arg2: object value
            al3.Print();


            al3.InsertRange(0, new int[] { -20, -15, -5 }); // arg1: int index, arg2: ICollection c
            al3.Print();


            ArrayList al7 = ArrayList.ReadOnly(al3);
            Console.WriteLine(al7.IsReadOnly); // true


            al3.Remove(5); // arg1: object value // removes first occurrence of the value // if value not found, no exception is thrown
            al3.Print();

            al3.RemoveAt(0); // arg1: int index // removes element at the index
            al3.Print();

            al3.RemoveRange(0, 2); // arg1: int index, arg2: int count // removes count elements starting from index
            al3.Print();

            // Give arraylist with repeated values
            ArrayList al8 = ArrayList.Repeat(-1, 5); // arg1: object value, arg2: int count
            al8.Print();


            // Reverse
            al3.Reverse(); // reverses the arraylist
            al3.Print();
            // Other overload
            // startIndex, count

            // SetRange
            al3.SetRange(0, new int[] { 100, 200 }); // arg1: int index, arg2: ICollection c
            al3.Print();


            // Synchronized -> Creates a thread safe wrapper around IList
            ArrayList al9 = ArrayList.Synchronized(al3);


            // ToArray
            int[] arr2 = (int[])al3.ToArray(typeof(int));
            Console.WriteLine(String.Join(", ", arr2));


            // TrimToSize -> sets the capacity to the actual number of elements
            al3.TrimToSize();
        }
    }
}
