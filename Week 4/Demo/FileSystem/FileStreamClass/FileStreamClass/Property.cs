using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStreamClass
{
    internal class Property
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream("example.txt", FileMode.Create);

            Console.WriteLine("CanRead: " + fs.CanRead); // bool CanRead { get; }

            Console.WriteLine("CanWrite: " + fs.CanWrite); // bool CanWrite { get; }

            Console.WriteLine("CanSeek: " + fs.CanSeek); // bool CanSeek { get; }

            Console.WriteLine("IsAsync: " + fs.IsAsync); // bool IsAsync { get; }

            Console.WriteLine("Length: " + fs.Length); // long Length { get; }

            Console.WriteLine("Position: " + fs.Position); // long Position { get; set; }

            Console.WriteLine("Name: " + fs.Name); // string Name { get; }

            SafeFileHandle handle = fs.SafeFileHandle; // SafeFileHandle SafeFileHandle { get; }
            Console.WriteLine("SafeFileHandle: " + handle.ToString());
        }
    }
}
