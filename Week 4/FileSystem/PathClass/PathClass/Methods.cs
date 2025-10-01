using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PathClass
{
    internal class Methods
    {
        static void Main(string[] args)
        {
            string path1 = @"C:\Users\Public\Documents\Report.pdf";
            string path2 = @"D:\Backup\";
            string path3 = @"..\Images\Photo.jpg";


            // ChageExtension
            Console.WriteLine(Path.ChangeExtension(path1, "txt")); // Change file extension

            // Combine
            Console.WriteLine(Path.Combine(path2, path3)); // Combine two paths

            // EndInDirectorySeparator
            Console.WriteLine(Path.EndsInDirectorySeparator(path2)); // Check if path ends with a directory separator

            // Exists
            Console.WriteLine(Path.Exists(path1)); // Check if path exists

            // GetDirectoryName
            Console.WriteLine(Path.GetDirectoryName(path1)); // Get directory name from path

            // GetExtension
            Console.WriteLine(Path.GetExtension(path1)); // Get file extension from path

            // GetFileName
            Console.WriteLine(Path.GetFileName(path1)); // Get file name from path

            // GetFileNameWithoutExtension
            Console.WriteLine(Path.GetFileNameWithoutExtension(path1)); // Get file name without extension

            // GetFullPath
            Console.WriteLine(Path.GetFullPath(path3)); // Get full path

            // GetInvalidFileNameChars
            char[] invalidFileNameChars = Path.GetInvalidFileNameChars(); // Get invalid file name characters
            //Console.WriteLine("InvalidFileNameChars: " + string.Join(", ", invalidFileNameChars));

            // GetInvalidPathChars
            char[] invalidPathChars = Path.GetInvalidPathChars(); // Get invalid path characters
            //Console.WriteLine("InvalidPathChars: " + string.Join(", ", invalidPathChars));

            // GetPathRoot -> Empty if no root
            Console.WriteLine(Path.GetPathRoot(path2)); // Get root of the path

            // GetRandomFileName
            Console.WriteLine(Path.GetRandomFileName()); // Generate a random file name

            // GetRelativePath -> If don't share a root second path is returned
            Console.WriteLine(Path.GetRelativePath(path2, path3)); // Get relative path from one path to another

            // GetTempFileName -> Creates a 0-byte file in temp folder
            //Console.WriteLine(Path.GetTempFileName()); // Generate a temporary file name

            // HasExtension
            Console.WriteLine(Path.HasExtension(path1)); // Check if path has an extension

            // IsPathFullyQualified -> Absolute path
            Console.WriteLine(Path.IsPathFullyQualified(path1)); // Check if path is fully qualified

            // IsPathRooted -> Absolute or relative path
            Console.WriteLine(Path.IsPathRooted(path1)); // Check if path is rooted

            // Join -> Simply joins two paths does not resolve like Combine it can produce invalid paths by joining two absolute paths
            // It simply concatenates them with a directory separator if needed does not check if paths are valid
            Console.WriteLine(Path.Join(path2, path1)); // Join two paths

            // TrimEndingDirectorySeparator
            Console.WriteLine(Path.TrimEndingDirectorySeparator(path2)); // Trim ending directory separator
        }
    }
}
