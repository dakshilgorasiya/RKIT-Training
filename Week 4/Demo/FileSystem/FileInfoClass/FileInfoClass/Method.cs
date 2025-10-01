using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileInfoClass
{
    internal class Method
    {
        static void Main(string[] args)
        {
            FileInfo fileInfo = new FileInfo(@".\example.txt");

            // AppendText
            using (StreamWriter writer = fileInfo.AppendText())
            {
                writer.WriteLine("Appending a new line to the file.");
            }

            // CopyTo
            FileInfo copiedFile = fileInfo.CopyTo(@".\example_copy.txt", true); // true to overwrite if exists

            // Create
            FileInfo newFile = new FileInfo(@".\newfile.txt");
            using (FileStream fs = newFile.Create())
            {
                
            }

            // CreateText
            using (StreamWriter writer = newFile.CreateText())
            {
                writer.WriteLine("Creating a new text file and writing to it.");
            }

            // Delete
            if (copiedFile.Exists)
            {
                copiedFile.Delete();
            }

            // MoveTo
            if (newFile.Exists)
            {
                //newFile.MoveTo(@".\moved_newfile.txt");
            }

            // Open
            using(FileStream fs = fileInfo.Open(FileMode.Open, FileAccess.Read))
            {
                
            }

            // OpenRead
            using (FileStream fs = fileInfo.OpenRead())
            {

            }

            // OpenText
            using(StreamReader reader = fileInfo.OpenText())
            {

            }

            // OpenWrite
            using (FileStream fs = fileInfo.OpenWrite())
            {

            }

            // Replace
            // First argument is the destination file, second is the backup file which will be created
            // Return value is a FileInfo object of the replaced file not of backup file
            FileInfo replacedFile = fileInfo.Replace(@".\newfile.txt", @".\backup.txt");
            Console.WriteLine("Replaced file created at: " + replacedFile.FullName);
        }
    }
}
