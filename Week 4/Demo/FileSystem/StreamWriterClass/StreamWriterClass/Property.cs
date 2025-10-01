using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamWriterClass
{
    internal class Property
    {
        static void Main(string[] args)
        {
            StreamWriter sw = new StreamWriter("file.txt");

            Console.WriteLine(sw.AutoFlush); // get AutoFlush property
            //sw.AutoFlush = true; // set AutoFlush property

            Console.WriteLine(sw.Encoding); // get Encoding property

            Console.WriteLine(sw.BaseStream); // get BaseStream property
        }
    }
}
