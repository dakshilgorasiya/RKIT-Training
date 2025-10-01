using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryInfoClass
{
    internal class Method
    {
        static void Main(string[] args)
        {
            DirectoryInfo directoryInfo1 = new DirectoryInfo(@"D:\temp");

            //Create the directory if it does not exist
            if (!directoryInfo1.Exists)
            {
                // If Directory already exists, this method does nothing.
                directoryInfo1.Create();
            }

            // If sub directory already exists, this method does nothing.
            // Create sub directory
            DirectoryInfo subDirectory = directoryInfo1.CreateSubdirectory("SubDirectory");

            // Delete the directory
            //subDirectory.Delete(); // This will throw an IOException if the directory is not empty.
            //directoryInfo1.Delete(true); // true parameter will delete the directory, its subdirectories, and all files.

            // Recursively enumerate all files in the directory and its subdirectories
            // AllDirectories or TopDirectoryOnly
            // * is search pattern to match all files
            //IEnumerable<DirectoryInfo> directoryInfos = directoryInfo1.EnumerateDirectories("*txt", SearchOption.AllDirectories);
            //foreach (DirectoryInfo dir in directoryInfos)
            //{
            //    Console.WriteLine("Sub Directory: " + dir.Name);
            //}

            // Recursively enumerate all files in the directory and its subdirectories
            // use *.txt to match only text files
            //IEnumerable<FileInfo> fileInfos = directoryInfo1.EnumerateFiles("*", SearchOption.AllDirectories);
            //foreach(FileInfo file in fileInfos)
            //{
            //    Console.WriteLine("File Name: " + file.Name);
            //}

            //IEnumerable<FileSystemInfo> fileSystemInfos = directoryInfo1.EnumerateFileSystemInfos("*", SearchOption.AllDirectories);
            //foreach(FileSystemInfo fsi in fileSystemInfos)
            //{
            //    Console.WriteLine("File System Info: " + fsi.Name + " Type " + fsi.GetType().Name);
            //}


            //DirectoryInfo[] directoryInfos = directoryInfo1.GetDirectories();
            //foreach (DirectoryInfo dir in directoryInfos)
            //{
            //    Console.WriteLine("Sub Directory: " + dir.Name);
            //}

            //FileInfo[] fileInfos = directoryInfo1.GetFiles();
            //foreach (FileInfo file in fileInfos)
            //{
            //    Console.WriteLine("File Name: " + file.Name);
            //}

            //FileSystemInfo[] fileSystemInfos = directoryInfo1.GetFileSystemInfos();
            //foreach (FileSystemInfo fsi in fileSystemInfos)
            //{
            //    Console.WriteLine("File System Info: " + fsi.Name + " Type " + fsi.GetType().Name);
            //}

            // Move the directory
            //directoryInfo1.MoveTo(@"D:\tempNew");

            // ToString
            // Returns the original path that was passed to the constructor
            Console.WriteLine("Directory Path: " + directoryInfo1.ToString());
        }
    }
}
