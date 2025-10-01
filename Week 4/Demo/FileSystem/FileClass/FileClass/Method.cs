using System.IO;
using System.Text;

namespace FileClass
{
    internal class Method
    {
        static void Main(string[] args)
        {
            // AppendAllLines
            File.AppendAllLines("example.txt", new string[] { "First line", "Second line" });

            // AppendAllLinesAsync
            Async();


            // AppendAllText -> default encoding is UTF-8
            File.AppendAllText("example2.txt", "Appended text", Encoding.Unicode); // UTF-16
            // Also have AppendAllTextAsync

            // AppendText
            using(StreamWriter streamWriter = File.AppendText("example3.txt"))
            {
                streamWriter.WriteLine("Appended text");
            }


            // Copy
            File.Copy("example.txt", "example_copy.txt", true); // true to overwrite if exists

            // Create
            File.Create("example_create.txt").Close();  // By defaule it does not close the file
            // other overloads with buffer size and FileOptions

            // CreateText
            using(StreamWriter streamWriter = File.CreateText("example_createText.txt"))
            {
                streamWriter.WriteLine("Created text");
            }

            // Delete
            File.Delete("example_create.txt");

            // Exists
            Console.WriteLine(File.Exists("example.txt")); // true

            // GetAttributes
            FileAttributes attributes = File.GetAttributes("example.txt");
            Console.WriteLine(attributes.ToString());

            // GetCreationTime
            Console.WriteLine(File.GetCreationTime("example.txt"));
            Console.WriteLine(File.GetCreationTimeUtc("example.txt"));

            // GetLastAccessTime
            Console.WriteLine(File.GetLastAccessTime("example.txt"));
            Console.WriteLine(File.GetLastAccessTimeUtc("example.txt"));

            // GetLastWriteTime
            Console.WriteLine(File.GetLastWriteTime("example.txt"));
            Console.WriteLine(File.GetLastWriteTimeUtc("example.txt"));

            // Move
            File.Move("example_copy.txt", "example_moved.txt", true); // true to overwrite if exists

            // Open
            using(FileStream fs = File.Open("example.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                // Read or write to the file
            }

            // OpenRead
            using(FileStream fs = File.OpenRead("example.txt"))
            {
                // Read from the file
            }

            // OpenText
            using(StreamReader streamReader = File.OpenText("example.txt"))
            {
                string content1 = streamReader.ReadToEnd();
            }

            // OpenWrite
            using(FileStream fs = File.OpenWrite("example.txt"))
            {
                // Write to the file
            }

            // ReadAllBytes
            byte[] bytes = File.ReadAllBytes("example3.txt");
            //Console.WriteLine(Encoding.UTF8.GetString(bytes));
            // Also have ReadAllBytesAsync

            // ReadAllLines
            string[] lines = File.ReadAllLines("example3.txt");
            // Also have ReadAllLinesAsync

            // ReadAllText
            string content = File.ReadAllText("example3.txt");
            // Also have ReadAllTextAsync

            // ReadLines
            // More efficient for large files as it uses lazy evaluation
            IEnumerable<string> lines2 = File.ReadLines("example3.txt");
            // Also have ReadLinesAsync and ReadLines with encoding

            // Replace
            // Replce content of sourse to destination and create a backup of destination
            //File.Replace("example3.txt", "example_moved.txt", "backup.txt"); // source file, destination file, backup file

            // SetAttributes
            // Make file hidden
            //File.Create("hidden_example.txt").Close();
            FileAttributes fileAttributes = File.GetAttributes("hidden_example.txt");
            fileAttributes |= FileAttributes.Hidden;
            // To unhide it fileAttributes &= ~FileAttributes.Hidden;
            File.SetAttributes("hidden_example.txt", fileAttributes);

            // SetCreationTime
            File.SetCreationTime("example.txt", DateTime.Now.AddDays(-5));
            // Other
            // SetCreationTimeUtc, SetLastAccessTime, SetLastAccessTimeUtc, SetLastWriteTime, SetLastWriteTimeUtc

            // WriteAllBytes
            byte[] data = Encoding.UTF8.GetBytes("Hello, World!");
            File.WriteAllBytes("example_bytes.txt", data);
            // Also have WriteAllBytesAsync

            // WriteAllLines
            File.WriteAllLines("example_lines.txt", new string[] { "Line 1", "Line 2" });
            // Overloads -> with encoding, and For IEnumerable<string> with and without encoding
            // Also have WriteAllLinesAsync

            // WriteAllText
            File.WriteAllText("example_text.txt", "Hello, World!", Encoding.UTF8);
            // Overload without encoding and for ReadOnlySpan<char>
            // Also have WriteAllTextAsync
        }

        async static void Async()
        {
            // AppendAllLinesAsync
            await File.AppendAllLinesAsync("example_async.txt", new string[] { "First line", "Second line" });
        }
    }
}
