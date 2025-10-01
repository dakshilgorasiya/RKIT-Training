using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreanReaderClass
{
    internal class Property
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("example.txt");

            // Type -> System.IO.Stream
            Console.WriteLine("BaseStream: " + reader.BaseStream.ToString()); // Gets the underlying stream of the StreamReader

            // Type -> System.Text.Encoding 
            Console.WriteLine("CurrentEncoding: " + reader.CurrentEncoding.ToString()); // Gets the current character encoding used by the StreamReader

            // Type -> System.Boolean
            Console.WriteLine("EndOfStream: " + reader.EndOfStream); // Indicates whether the StreamReader has reached the end of the stream
        }
    }
}
