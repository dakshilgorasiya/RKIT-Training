namespace IO
{
    /// <summary>
    /// A helper class for file input and output operations.
    /// </summary>
    public static class IOHelper
    {
        /// <summary>
        /// A method to read the content of a file.
        /// </summary>
        /// <param name="filePath">A path of file to read content</param>
        /// <returns>Content of string</returns>
        public static string? ReadFile(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("File not found.", filePath);
                }
                string fileContent = File.ReadAllText(filePath);
                return fileContent;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found : " + filePath);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading file: " + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// A method to write content to a file.
        /// </summary>
        /// <param name="filePath">Path of file to write</param>
        /// <param name="content">Content to write</param>
        public static void WriteFile(string filePath, string content)
        {
            try
            {
                File.WriteAllText(filePath, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing to file: " + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// A method to delete a file.
        /// </summary>
        /// <param name="filePath">Path of file to delete</param>
        public static void DeleteFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                else
                {
                    throw new FileNotFoundException("File not found.", filePath);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found : " + filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting file: " + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// A method to get metadata of all files in the "Vault" directory.
        /// </summary>
        /// <returns>Array of FileInfo representing each file in Vault folder</returns>
        public static IEnumerable<FileInfo> getAllFileMetadata()
        {
            string path = Path.Combine("Vault");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            return directoryInfo.EnumerateFiles();
        }
    }
}
