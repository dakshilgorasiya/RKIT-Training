using System;
using System.IO;

namespace FileReadWrite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileOperations fileOperation = new FileOperations();

            //Console.WriteLine(fileOperation.ReadFromFile("sample.txt"));
            //fileOperation.ReadUsingStreamReader("sample.txt");
            //fileOperation.ReadUsingFileStream("sample.txt");

            string content = "Hello, World!\nWelcome to File I/O in C#.";
            //fileOperation.WriteToFile("output.txt", content);
            //fileOperation.WriteUsingStreamWriter("output.txt", content);
            //fileOperation.AppendToFile("output.txt", "\nAppended line.");
            //fileOperation.AppendUsingStreamWriter("output.txt", "\nAppended line using StreamWriter.");
            //fileOperation.WriteUsingFileStream("output.txt", "\nAppended line using FileStream.");
        }
    }
    class FileOperations
    {
        public string ReadFromFile(string filePath)
        {
            try
            {
                string content = File.ReadAllText(filePath);
                return content;
            }
            catch (Exception ex)
            {
                return $"Error reading file: {ex.Message}";
            }
        }
        public void ReadUsingStreamReader(string filePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
        }
        public void WriteToFile(string filePath, string content)
        {
            try
            {
                File.WriteAllText(filePath, content);
                Console.WriteLine("File written successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        }
        public void WriteUsingStreamWriter(string filePath, string content)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(content);
                }
                Console.WriteLine("File written successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        }
        public void AppendToFile(string filePath, string content)
        {
            try
            {
                File.AppendAllText(filePath, content);
                Console.WriteLine("Content appended successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error appending to file: {ex.Message}");
            }
        }
        public void AppendUsingStreamWriter(string filePath, string content)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, append: true))
                {
                    writer.WriteLine(content);
                }
                Console.WriteLine("Content appended successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error appending to file: {ex.Message}");
            }
        }

        public void ReadUsingFileStream(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                fs.Seek(10, SeekOrigin.Begin); // Move to the 10th byte from the start
                byte[] buffer = new byte[50];
                fs.Read(buffer, 0, buffer.Length);
                string result = System.Text.Encoding.UTF8.GetString(buffer);
                Console.WriteLine(result);
            }
        }
        public void WriteUsingFileStream(string filePath, string content)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write))
            {
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(content);
                fs.Write(buffer, 0, buffer.Length); 
            }
        }
    }
}
