using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileInfoClass
{
    internal class Property
    {
        static void Main(string[] args)
        {
            string filePath = @".\example.txt";

            FileInfo fileInfo = new FileInfo(filePath);

            // Gets the directory information of the file.
            DirectoryInfo directoryInfo = fileInfo.Directory;

            // Gets the directory name of the file.
            Console.WriteLine("Directory Name: " + fileInfo.DirectoryName);

            // Check if file exists.
            Console.WriteLine("File Exists: " + fileInfo.Exists);

            // Checks if the file is read-only.
            Console.WriteLine("Is Read-Only: " + fileInfo.IsReadOnly);

            // Length of the file in bytes.
            Console.WriteLine("File Length (in bytes): " + fileInfo.Length);

            // Gets the file name with extension.
            Console.WriteLine("File Name with Extension: " + fileInfo.Name);
        }
    }
}
