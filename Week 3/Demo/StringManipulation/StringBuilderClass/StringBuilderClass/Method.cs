using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBuilderClass
{
    internal class Method
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder("ABCDE");

            // Append
            sb.Append("FG");
            Console.WriteLine(sb); // ABCDEFG

            sb.Append(5);
            Console.WriteLine(sb); // ABCDEFG5

            sb.Append(true);
            Console.WriteLine(sb); // ABCDEFG5True

            sb.Append(45.45);
            Console.WriteLine(sb); // ABCDEFG5True45.45

            // AppendFormat
            sb.AppendFormat(" - {0} - {1}", "Hello", 123);
            Console.WriteLine(sb); // ABCDEFG5True45.45 - Hello - 123

            // AppendJoin
            string[] s = { "A", "B", "C" };
            sb.AppendJoin(",", s);
            Console.WriteLine(sb); // ABCDEFG5True45.45 - Hello - 123A,B,C

            // Clear
            sb.Clear();
            Console.WriteLine(sb);

            // AppendLine
            sb.AppendLine("Hello");
            sb.AppendLine("World");
            Console.WriteLine(sb); // Hello\nWorld\n

            // CopyTo
            char[] buffer = new char[5];
            sb.CopyTo(0, buffer, 0, 5); // arg: sourceIndex, destination array, destinationIndex, count
            Console.WriteLine(buffer); // Hello

            // EnsureCapacity
            // If the current capacity is less than the capacity parameter, memory for this instance is reallocated to hold at least capacity number of characters; otherwise, no memory is changed.
            sb.EnsureCapacity(100);
            // Equals
            StringBuilder sb2 = new StringBuilder("Hello\nWorld\n");
            Console.WriteLine(sb.Equals(sb2)); // True

            // Insert
            // It take int, decimal, bool, strig, char as second parameter
            sb.Insert(5, "Insert");
            Console.WriteLine(sb); // HelloInsert\nWorld\n

            // Remove
            sb.Remove(5, 6); // arg: startIndex, length
            Console.WriteLine(sb); // Hello\nWorld\n

            // Replace
            sb.Replace("World", "CSharp");
            Console.WriteLine(sb); // Hello\nCSharp\n
            // other
            // string, string, int(startindex), int(count),
            // char, char, int(startindex), int(count)
            //char, char
            // ReadOnlySpan<char>, ReadOnlySpan<char>
            // ReadOnlySpan<char>, ReadOnlySpan<char>, int(startindex), int(count)

            // ToString
            Console.WriteLine(sb.ToString()); // Hello\nCSharp\n
            Console.WriteLine(sb.ToString(1, 5)); // ello\n
        }
    }
}
