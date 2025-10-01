using System.IO;

namespace DirectoryClass
{
    internal class Method
    {
        static void Main(string[] args)
        {
            string path = @"D:\temp";

            // Create the directory.
            DirectoryInfo newDir = Directory.CreateDirectory(@"D:\temp1");

            // Create temp directory.
            //DirectoryInfo tempDir = Directory.CreateTempSubdirectory("MYTEMP");
            //Console.WriteLine($"The temp directory is {tempDir.FullName}");

            // Delete the directory.
            //Directory.Delete(@"D:\temp1", true);

            // Get the filesystem entries.
            IEnumerable<string> entries = Directory.EnumerateFileSystemEntries(path, "*", SearchOption.AllDirectories);
            foreach (string entry in entries)
            {
                Console.WriteLine(entry);
            }

            // Exists
            bool isExists = Directory.Exists(path);
            Console.WriteLine(isExists);

            // Get CreationTime
            Console.WriteLine(Directory.GetCreationTime(path));
            // Other
            // GetLastAccessTime, GetLastWriteTime, GetCreationTimeUtc, GetLastAccessTimeUtc, GetLastWriteTimeUtc

            // Current Directory
            Console.WriteLine(Directory.GetCurrentDirectory());

            // Get Directory 
            foreach (string dir in Directory.GetDirectories(path))
            {
                Console.WriteLine(dir);
            }

            // Get directory root
            Console.WriteLine(Directory.GetDirectoryRoot(path));

            // Get files
            foreach (string file in Directory.GetFiles(path, "*.xlsx",SearchOption.AllDirectories))
            {
                Console.WriteLine(file);
            }

            // Get Filesystem entries
            foreach (string entry in Directory.GetFileSystemEntries(path))
            {
                Console.WriteLine(entry);
            }

            // Get Logical drives
            foreach (string drive in Directory.GetLogicalDrives())
            {
                Console.WriteLine(drive);
            }

            // Get Parent
            DirectoryInfo parent = Directory.GetParent(path);
            Console.WriteLine(parent.FullName);

            // Move
            //Directory.Move(@"D:\temp1", @"D:\temp2");

            // Other
            // SetCreationTime(path, DateTime);
            // SetCreationTimeUtc, SetLastAccessTime, SetLastAccessTimeUtc, SetLastWriteTime, SetLastWriteTimeUtc

            // SetCurrentDirectory
            Console.WriteLine("\n\n\n\n");
            Directory.SetCurrentDirectory(@"D:\temp1");
            Console.WriteLine(Directory.GetCurrentDirectory());
        }
    }
}
