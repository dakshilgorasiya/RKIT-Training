using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreanReaderClass
{
    internal class Method
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("example.txt");

            // Close
            //reader.Close(); // Closes the StreamReader and the underlying stream

            reader.DiscardBufferedData(); // Discards any data that has been buffered by the StreamReader

            //reader.Dispose();

            Console.WriteLine(reader.Peek()); // return next character without consuming it or -1 if no more characters

            //Read
            //Console.WriteLine((char)reader.Read()); // Read next char and move to next position

            //Span<char> buffer = new Span<char>(new char[5]);
            //int charRead = reader.Read(buffer); // Read chars into buffer
            //Console.WriteLine(buffer.ToString());

            //char[] bufferArray = new char[5];
            //bufferarray, buffer start index, number of chars to read
            //int charReadArray = reader.Read(bufferArray, 0, bufferArray.Length);
            //Console.WriteLine(bufferArray);

            // also have ReadAsync(buffer, int, int)


            // ReadLine
            //Console.WriteLine(reader.ReadLine());
            // also have ReadLineAsync()

            // ReadToEnd
            Console.WriteLine(reader.ReadToEnd());
            // also have ReadToEndAsync()
        }
    }
}
