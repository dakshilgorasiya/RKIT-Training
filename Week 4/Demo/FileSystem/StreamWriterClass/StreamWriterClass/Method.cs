using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamWriterClass
{
    internal class Method
    {
        static void Main(string[] args)
        {
            StreamWriter sw = new StreamWriter("file.txt");


            // Write buffered data to the underlying stream and close it
            //sw.Close();
            //sw.Dispose();
            // also have DisposeAsync()

            sw.Flush(); // Write buffered data to the underlying stream
            // also have FlushAsync()


            // Write
            sw.Write("{0}", 123); // format, arg0(object)

            char[] buffer = new char[] { 'a', 'b', 'c', 'd', 'e' };
            sw.Write(buffer, 1, 2); // buffer, startIndex, count

            sw.Write("HI"); // string

            sw.Write(buffer); // char[]

            sw.Write('Z'); // char

            // WriteAsync
            // (char), (string), (char[], int, int)

            sw.WriteLine("HELLo");
            sw.WriteLine("HI");

            sw.Dispose();
        }
    }
}
