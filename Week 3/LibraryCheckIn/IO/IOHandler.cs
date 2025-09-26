using System.IO;

namespace IO
{
    // public
    // Reason: Required outside this assembly
    public static class IOHandler
    {
        /// <summary>
        /// Read content of a file and return as string
        /// </summary>
        /// <param name="filePath">Path of the file</param>
        /// <returns> if file exists string containing content of file else null</returns>
        public static string? ReadFile(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("File not found.", filePath);
                }
                using (StreamReader reader = new StreamReader(filePath))
                {
                    // Read complete file and trim any trailing new line or space characters
                    return reader.ReadToEnd().Trim();
                }
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("File not found : " +  filePath);
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Write content to a file
        /// </summary>
        /// <param name="filePath">Path of file to write</param>
        /// <param name="content">Content to write into file</param>
        public static void writeFile(string filePath, string content)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.Write(content);
                }
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
