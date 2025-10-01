using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBuilderClass
{
    internal class Constructor
    {
        static void Main(string[] args)
        {
            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder("Hello, World!");
            StringBuilder sb3 = new StringBuilder(50); // capacity of 50 characters It can exceed this capacity it will assign new memory
            StringBuilder sb4 = new StringBuilder("Hello, World!", 50); // capacity of 50 characters
            StringBuilder sb5 = new StringBuilder(5, 50); // initial capacity of 5 characters and maximum capacity of 50 characters if exceed maximum capacity it will throw an exception
            StringBuilder sb6 = new StringBuilder("Hello, World!", 5, 5, 50); // substring of "Hello, World!" starting at index 5 with length 5 and maximum capacity of 50 characters
        }
    }
}
