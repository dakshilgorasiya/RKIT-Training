using Domain;
using System.Data;
using System.Text;

namespace LibraryCheckIn
{
    internal static class Processing
    {
        /// <summary>
        /// Parse CSV content and write to DataTable
        /// </summary>
        /// <param name="content">Content of comma seperated CSV file</param>
        /// <param name="table">DataTable reference in which data will be return</param>
        public static void ParseCSV(string content, DataTable table)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(content))
                {
                    throw new ArgumentNullException("No content found");
                }

                string[] lines = content.Split('\n');

                if (lines.Length == 0)
                {
                    throw new ArgumentNullException("No content found");
                }

                if (lines.Length == 1)
                {
                    Console.WriteLine("Warning :: No rows found");
                }

                for (int i = 1; i < lines.Length; i++)
                {
                    // fileds of one row
                    string[] fields = lines[i].Split(",");
                    if(fields.Length != 4)
                    {
                        Console.WriteLine($"Skipping row {i} because of inappopriate number of columns, columns found {fields.Length}");
                        continue;
                    }
                    bool isIdValid = int.TryParse(fields[0], out int Id);
                    string Title = fields[1];
                    string Author = fields[2];
                    bool isBookConditionValid = Enum.TryParse<BookCondition>(fields[3], out BookCondition BookCondition);
                    if(isIdValid && isBookConditionValid)
                    {
                        table.Rows.Add(Id, Title, Author, BookCondition);
                    }
                    else
                    {
                        if(!isIdValid)
                        {
                            Console.WriteLine($"Skipping row {i} because of invalid Id : {fields[0]}");
                        }
                        if(!isBookConditionValid)
                        {
                            Console.WriteLine($"Skipping row {i} because of invalid book condition : {fields[3]}");
                        }
                    }
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Given file is empty");
                throw;
            }
        }

        /// <summary>
        /// Map DataTable rows to List of Book objects
        /// </summary>
        /// <param name="table">DataTable having four columns Id, Title, Author, BookCondition</param>
        /// <returns>List of Book containing all records of table</returns>
        public static List<Book> MapDataTableToBooks(DataTable table)
        {
            List<Book> books = new List<Book>();

            foreach (DataRow row in table.Rows)
            {
                int id = (int)row["Id"];
                string title = (string)row["Title"];
                string author = (string)row["Author"];
                BookCondition bookCondition = (BookCondition)row["BookCondition"];

                books.Add(
                    new Book()
                    {
                        Id = id,
                        Title = title,
                        Author = author,
                        BookCondition = bookCondition
                    }
                );
            }

            return books;
        }

        /// <summary>
        /// Create summary of books by calculating penalty for each book
        /// </summary>
        /// <param name="books">List of books containing book return records</param>
        /// <returns>List of string representing book title, author and penalty between 1 to 100</returns>
        public static List<string> ProcessByBook(List<Book> books)
        {
            List<string> summaries = new List<string>();

            summaries = books
                .GroupBy(b => new { b.Id, b.Title, b.Author }) // As there can be multiple book entry for same book
                .Select(b =>
                {
                    int totalPenalty = b.Sum(book => book.BookCondition switch
                    {
                        BookCondition.Damaged => 10,
                        BookCondition.Worn => 3,
                        BookCondition.Good => 0,
                        BookCondition.New => -1,
                    }); // calcaluate totalPenalty

                    int finalScore = Math.Clamp(totalPenalty, 0, 100); // Clamp it to [0, 100]

                    return $"'{b.Key.Title}' by '{b.Key.Author}' with penalty {finalScore}";
                }).ToList();

            return summaries;
        }

        /// <summary>
        /// Count number of books by their condition
        /// </summary>
        /// <param name="books">List of books containing book return records</param>
        /// <returns>Dictionary containing total books by condition</returns>
        public static Dictionary<BookCondition, int> CountByCondition(List<Book> books)
        {
            Dictionary<BookCondition, int> conditionCounts = new Dictionary<BookCondition, int>();
            foreach (BookCondition bookCondition in Enum.GetValues(typeof(BookCondition)))
            {
                conditionCounts[bookCondition] = books.Count(b => b.BookCondition == bookCondition);
            }
            return conditionCounts;
        }

        /// <summary>
        /// Finds top five books with highest penalty
        /// </summary>
        /// <param name="books">List of books containing book return records</param>
        /// <returns>List of at most 5 book containing book title, author and totalpenalty</returns>
        public static List<string> TopFivePenaltyBook(List<Book> books)
        {
            List<string> topFivePenalty = new List<string>();

            topFivePenalty = books
                .GroupBy(b => new { b.Id, b.Title, b.Author })
                .Select(b =>
                {
                    int totalPenalty = b.Sum(book => book.BookCondition switch
                    {
                        BookCondition.Damaged => 10,
                        BookCondition.Worn => 3,
                        BookCondition.Good => 0,
                        BookCondition.New => -1,
                    });

                    int finalScore = Math.Clamp(totalPenalty, 0, 100);

                    return new
                    {
                        b.Key.Title,
                        b.Key.Author,
                        Penalty = finalScore
                    };
                })
                .OrderByDescending(b => b.Penalty)
                .Take(5)
                .Select(b => $"'{b.Title}' by '{b.Author}' with penalty {b.Penalty}")
                .ToList();

            return topFivePenalty;
        }

        /// <summary>
        /// Generate content of report to write to file
        /// </summary>
        /// <param name="time">Time when report created</param>
        /// <param name="totalReturn">Total number of books return</param>
        /// <param name="countByBookCondition">Dictionary having total book by their condition</param>
        /// <param name="topFivePenalty">List of string representing top 5 book by penalty</param>
        /// <returns></returns>
        public static string GenerateReportContent(DateTime time, int totalReturn, Dictionary<BookCondition, int> countByBookCondition, List<string> topFivePenalty)
        {
            StringBuilder sb = new StringBuilder("Report generated using Library Check In Command Utility");

            sb.AppendLine();

            sb.AppendLine("Time: " + time.ToString("yyyy-mm-dd HH:mm:ss"));

            sb.AppendLine();

            sb.AppendLine($"Total returns : {totalReturn}");

            sb.AppendLine();

            sb.AppendLine("Total book by condition");
            foreach(BookCondition bookCondition in Enum.GetValues(typeof(BookCondition)))
            {
                sb.AppendLine($"{bookCondition}: {countByBookCondition[bookCondition]}");
            }

            sb.AppendLine();

            sb.AppendLine("Top five penalty books : ");
            foreach(string book in topFivePenalty)
            {
                sb.AppendLine(book);
            }

            return sb.ToString();
        }
    }
}
