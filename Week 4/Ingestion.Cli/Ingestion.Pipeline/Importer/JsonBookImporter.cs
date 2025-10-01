using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Ingestion.Pipeline.Importer
{
    /// <summary>
    /// Class to import book data from JSON files.
    /// </summary>
    public class JsonBookImporter : FileImporter<Book>
    {
        /// <summary>
        /// Parse json file and return list of books.
        /// </summary>
        /// <param name="filePath">Path of .json file to read</param>
        /// <returns>IEnumerable of Book representing parsed data of .json file</returns>
        public override IEnumerable<Book> Import(string filePath)
        {
            // To store all book data from the file
            List<Book> books = new List<Book>();

            // To extract file name from the file path for logging purposes
            string fileName = Path.GetFileName(filePath);

            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("File not found.", filePath);
                }

                // Read complete file content
                string content = File.ReadAllText(filePath);
                if(content == null)
                {
                    Console.WriteLine($"File {filePath} is empty");
                    return books;
                }

                // Parse JSON content
                JArray jsonArray = JArray.Parse(content);

                int i = 1; // To show error message with entry number;
                foreach(JToken item in jsonArray)
                {
                    // Check if all required fields are present
                    if (item["Id"] == null || item["Title"] == null || item["Author"] == null || item["Condition"] == null)
                    {
                        Console.WriteLine($"{fileName} :: Skipping entry {i} because of inappopriate number of fields");
                        continue;
                    }

                    // Extract and validate each field
                    string? idStr = item["Id"].Value<string>();
                    string? Title = item["Title"].Value<string>();
                    string? author = item["Author"].Value<string>();
                    string? conditionStr = item["Condition"].Value<string>();

                    // Validate Id
                    bool isIdValid = int.TryParse(idStr, out int Id);

                    // Validate BookCondition
                    bool isBookConditionValid = Enum.TryParse<BookCondition>(conditionStr, out BookCondition condition);

                    if (isIdValid && isBookConditionValid)
                    {
                        Book book = new Book
                        {
                            Id = Id,
                            Title = Title,
                            Author = author,
                            BookCondition = condition
                        };

                        // Add book to the list
                        books.Add(book);
                    }
                    else
                    {
                        if (!isIdValid)
                        {
                            Console.WriteLine($"{fileName} :: Skipping row {i} because of invalid Id : {idStr}");
                        }
                        if (!isBookConditionValid)
                        {
                            Console.WriteLine($"{fileName} :: Skipping entry {i} because of invalid book condition : {conditionStr}");
                        }
                        continue;
                    }
                    i++; // Increment entry number
                }
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine($"File not found {filePath}");
            }
            catch(Exception)
            {
                throw;
            }

            return books;
        }
    }
}
