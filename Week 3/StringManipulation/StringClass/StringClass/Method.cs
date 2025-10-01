using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringClass
{
    internal class Method
    {
        static void Main(string[] args)
        {
            String s1 = "Hello World";
            String s2 = "HI";

            // Shallow copy
            String? s3 = s1.Clone() as String;
            Console.WriteLine(s3);

            // Comapre
            // -1 when s1 < s2, 0 when s1 == s2, 1 when s1 > s2
            Console.WriteLine(String.Compare(s1, s2)); // arg1(string), arg2(string)

            Console.WriteLine(String.Compare(s1, 0, s2, 0, 1)); // arg1(string), arg1Index(int), arg2(string), arg2Index(int), length(int)

            Console.WriteLine(String.Compare(s1, 0, s2, 0, 1, true)); // arg1(string), arg1Index(int), arg2(string), arg2Index(int), length(int), ignoreCase(bool)

            // Comapre ordinal
            // faster than Compare method as direcly compares the binary value of each character
            Console.WriteLine(String.CompareOrdinal(s1, s2)); // arg1(string), arg2(string)

            Console.WriteLine(String.CompareOrdinal(s1, 0, s2, 0, 1)); // arg1(string), arg1Index(int), arg2(string), arg2Index(int), length(int)

            // ComapreTo
            Console.WriteLine(s1.CompareTo(s2)); // arg(string) -1
            Console.WriteLine(s2.CompareTo((object)s1)); // arg(object) 1

            // Concat
            Console.WriteLine(String.Concat(s1, s2)); // arg1(string), arg2(string)
            // other
            // 4 strings
            // 4 objects
            // 4 ReadOnlySpan<char>
            // 3 strings
            // 3 objects
            // 3 ReadOnlySpan<char>
            // 2 strings
            // 2 objects
            // 2 ReadOnlySpan<char>
            // object[]

            // Contains
            // Can take char also
            Console.WriteLine(s1.Contains("lo Wo")); // arg(string)
            Console.WriteLine(s1.Contains("lo wo", StringComparison.OrdinalIgnoreCase)); // arg(string), arg(StringComparison)

            // Copy
            // Deep copy
            String s4 = String.Copy(s1);
            Console.WriteLine(s4);

            // CopyTo
            Span<char> span = new char[20];
            s1.CopyTo(span);
            Console.WriteLine(span.ToString());

            Char [] charArray = new char[20];
            s1.CopyTo(0, charArray, 0, s1.Length); // sourceIndex(int), destination(char[]), destinationIndex(int), count(int)
            Console.WriteLine(charArray);

            // EndsWith also StartsWith
            Console.WriteLine(s1.EndsWith("rld")); // arg(string)

            // Equals
            Console.WriteLine(s1.Equals(s2)); // arg(string)
            Console.WriteLine(s1.Equals((object)s2)); // arg(object)
            Console.WriteLine(String.Equals(s1, s2)); // arg1(string), arg2(string)

            // Format
            Console.WriteLine(String.Format("This is {0} and {1}", s1, s2)); // arg(format(string), arg0(object), arg1(object), ...)

            // GetHashCode
            Console.WriteLine(s1.GetHashCode());

            // IndexOf also LastIndexOf
            Console.WriteLine(s1.IndexOf("o")); // arg(string) - first occurrence       
            Console.WriteLine(s1.IndexOf("o", 5)); // arg(string), arg(startIndex(int)) - occurrence after index 5

            // Insert
            Console.WriteLine(s1.Insert(5, " INSERTED ")); // arg(startIndex(int), value(string))


            // IsNullOrEmpty
            Console.WriteLine(String.IsNullOrEmpty(s1)); // arg(string)

            // IsNullOrWhiteSpace
            Console.WriteLine(String.IsNullOrEmpty(s2)); // arg(string)

            // Join
            string[] s = { "Hello", "World", "From", "Join" };
            Console.WriteLine(String.Join(" ", s)); // arg(separator(string), values(string[]))

            // PadLeft also PadRight
            Console.WriteLine(s2.PadLeft(5, '*')); // arg(totalWidth(int), paddingChar(char))

            // Remove
            Console.WriteLine(s1.Remove(5)); // arg(startIndex(int))

            // Replace
            Console.WriteLine(s1.Replace("World", "Everyone")); // arg(oldValue(string), newValue(string))

            // Split
            string[] words = s1.Split(' '); // arg(separator(char[]))
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }


            // Substring
            Console.WriteLine(s1.Substring(1, 2)); // arg(startIndex(int), length(int))

            // ToCharArray
            Console.WriteLine(s1.ToCharArray()); // returns char[]
            // ToCharArray(int startIndex, int length)

            // ToLower also ToUpper
            Console.WriteLine(s2.ToLower());

            // Trim, TrimStart, TrimEnd
            Console.WriteLine("  hi    ".Trim());

            // TryCopyTo
            Span<char> destination = new char[20];
            s1.TryCopyTo(destination);
            Console.WriteLine(destination.ToString());
        }
    }
}
