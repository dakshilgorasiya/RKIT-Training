using myNamespace1;
using static System.Math; // Using static class
using myNamespace1.nested; // Using nested namespace
//using Fs = fileNamespace; // Alias for namespace
using fileNamespace;
using System.Collections;

namespace UsingNamespace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //A.MyMethod();  // MyMethod in myNamespace1.A
            //MyFile.MyMethod();  // MyMethod in MyFile global namespace
            //B.MyMethod(); // MyMethod in myNamespace1.B
            //Fs.C.MyMethod(); // MyMethod in fileNamespace.C
            //Console.WriteLine(Sqrt(16)); // Using static class System.Math
            //myNamespace1.nested.D.MyMethod(); // MyMethod in myNamespace1.nested.D


            // ArrayList
            //ArrayList arrayList = new ArrayList();
            //arrayList.Add(1);
            //arrayList.Add("string");
            ////arrayList.Remove(1); // Remove item with value 1
            ////arrayList.RemoveAt(0); // Remove item at index 0
            //arrayList.Insert(2, 10);
            //Console.WriteLine("Size: " + arrayList.Count);
            //foreach (var item in arrayList)
            //{
            //    Console.WriteLine(item);
            //}

            // Hashtable
            //Hashtable hashtable = new Hashtable();
            //hashtable.Add("one", 1);
            //hashtable.Add("two", 2);
            //hashtable["three"] = 3; // Using indexer to add item
            //Console.WriteLine("Size: " + hashtable.Count);
            //Console.WriteLine(hashtable.ContainsKey("two")); // True
            //Console.WriteLine(hashtable.ContainsValue(4)); // False
            //Console.WriteLine(hashtable["three"]); // 3
            //foreach (string item in hashtable.Keys)
            //{
            //    Console.WriteLine(item);
            //}

            // List
            //List<int> list = new List<int>();
            //list.Add(1);
            //list.Add(2);
            //list.Add(3);
            //Console.WriteLine("Size: " + list.Count); // 3
            ////list.Remove(2); // Remove item with value 2
            ////list.RemoveAt(0); // Remove item at index 0
            //list.Insert(1, 10); // Insert 10 at index 1
            //Console.WriteLine(list.Contains(3)); // True
            //Console.WriteLine(list.Find(x => x > 2)); // 10
            //foreach (var item in list.FindAll(x => x > 1))
            //{
            //    Console.WriteLine(item); // 10, 2, 3
            //}

            // Dictionary
            //Dictionary<string, int> dictionary = new Dictionary<string, int>();
            //dictionary.Add("one", 1);
            //dictionary.Add("two", 2);
            //dictionary.Add("one", 10); // Throws exception as key "one" already exists
            //dictionary["three"] = 3; // Using indexer to add item
            //Console.WriteLine("Size: " + dictionary.Count); // 3
            //Console.WriteLine(dictionary.ContainsKey("two")); // True
            //Console.WriteLine(dictionary.ContainsValue(4)); // False
            //Console.WriteLine(dictionary["three"]); // 3
            //if (dictionary.TryGetValue("three", out int value))
            //{
            //    Console.WriteLine(value);
            //}
            //else
            //{
            //    Console.WriteLine("Key not found" + value);
            //}
            //foreach (string item in dictionary.Keys)
            //{
            //    Console.WriteLine(item);
            //}

            // Queue
            //Queue<int> queue = new Queue<int>();
            //queue.Enqueue(1);
            //queue.Enqueue(2);
            //queue.Enqueue(3);
            //Console.WriteLine("Size: " + queue.Count); // 3
            //Console.WriteLine(queue.Dequeue()); // 1 -> use with try-catch as it throws exception if queue is empty
            //Console.WriteLine(queue.Peek()); // 2

            // Stack
            //Stack<int> stack = new Stack<int>();
            //stack.Push(1);
            //stack.Push(2);
            //stack.Push(3);
            //Console.WriteLine("Size: " + stack.Count); // 3
            //Console.WriteLine(stack.Pop()); // 3 -> use with try-catch as it throws exception if stack is empty
            //Console.WriteLine(stack.Peek()); // 2
        }
    }
}

namespace myNamespace1
{
    class A
    {
        public static void MyMethod()
        {
            Console.WriteLine("MyMethod in myNamespace1.A");
        }
    }

    namespace nested
    {
        class D
        {
            public static void MyMethod()
            {
                Console.WriteLine("MyMethod in myNamespace1.nested.D");
            }
        }
    }
}