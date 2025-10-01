using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Ingestion.Pipeline.Importer
{
    /// <summary>
    /// Class to import book data from CSV files.
    /// </summary>
    public class CsvBookImporter : FileImporter<Book>
    {
        /// <summary>
        /// Parse csv file and return list of books.
        /// </summary>
        /// <param name="filePath">Path of .csv file to read</param>
        /// <returns>IEnumerable of Book representing parsed data of .csv file</returns>
        public override IEnumerable<Book> Import(string filePath)
        {
            // To store all book data from the file
            List<Book> books = new List<Book>();

            // Extract file name from the file path for logging purposes
            string fileName = Path.GetFileName(filePath);

            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("File not found.", filePath);
                }
                using (StreamReader reader = new StreamReader(filePath))
                {
                    // Read complete file and trim any trailing new line or space characters
                    if(!reader.EndOfStream)
                    {
                        string header = reader.ReadLine();
                    }


                    int i = 1; // To keep track of line number for error reporting
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine().Trim();

                        // Columns of a row
                        string[] fields = line.Split(',');

                        if (fields.Length != 4)
                        {
                            Console.WriteLine($"{fileName} :: Skipping row {i} because of inappopriate number of columns, columns found {fields.Length}");
                            continue;
                        }

                        // Extract and validate each field
                        bool isIdValid = int.TryParse(fields[0], out int Id);
                        string Title = fields[1];
                        string Author = fields[2];
                        bool isBookConditionValid = Enum.TryParse<BookCondition>(fields[3], out BookCondition BookCondition);

                        if(isIdValid && isBookConditionValid)
                        {
                            Book book = new Book
                            {
                                Id = Id,
                                Title = Title,
                                Author = Author,
                                BookCondition = BookCondition
                            };

                            // Add the book to the list
                            books.Add(book);
                        }
                        else
                        {
                            if (!isIdValid)
                            {
                                Console.WriteLine($"{fileName} :: Skipping row {i} because of invalid Id : {fields[0]}");
                            }
                            if (!isBookConditionValid)
                            {
                                Console.WriteLine($"{fileName} :: Skipping row {i} because of invalid book condition : {fields[3]}");
                            }
                        }

                        i++; // Increment line number
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found : " + filePath);
            }
            catch (Exception)
            {
                throw;
            }
            return books;
        }
    }
}
