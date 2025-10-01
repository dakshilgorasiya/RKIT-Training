using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryInfoClass
{
    internal class Property
    {
        static void Main(string[] args)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(@"D:\RKIT Training\Week 4");
            Console.WriteLine("Directory Exists: " + directoryInfo.Exists);
            Console.WriteLine("Directory Name: " + directoryInfo.Name);
            Console.WriteLine("Directory Parent: " + directoryInfo.Parent);
            Console.WriteLine("Directory Root: " + directoryInfo.Root);
        }
    }
}
