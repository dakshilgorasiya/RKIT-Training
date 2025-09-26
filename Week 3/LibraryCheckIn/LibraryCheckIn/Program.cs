using Domain;
using IO;
using System.Data;

namespace LibraryCheckIn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string csvFileName = $"returns_{DateTime.Now.ToString("yyyyMMdd")}.csv";

            // Path of .csv file
            string filePath = Path.Combine(".\\in", csvFileName);

            // Table to store return entry
            DataTable LibraryReturn = new DataTable("LibraryReturn");
            LibraryReturn.Columns.Add("Id", typeof(int));
            LibraryReturn.Columns.Add("Title", typeof(string));
            LibraryReturn.Columns.Add("Author", typeof(string));
            LibraryReturn.Columns.Add("BookCondition", typeof(BookCondition));

            try
            {
                // content of .csv file in raw form
                string? content = IOHandler.ReadFile(filePath);
                if (content != null)
                {
                    // LibraryReturn have data for book return
                    Processing.ParseCSV(content, LibraryReturn);

                    // LibraryReturn is mapped to List<Book> for LINQ query
                    List<Book> Books = Processing.MapDataTableToBooks(LibraryReturn);

                    // Summary of book with total pentalty
                    List<string> summaryByBook = Processing.ProcessByBook(Books);

                    Console.WriteLine();
                    foreach (string summary in summaryByBook)
                    {
                        Console.WriteLine(summary);
                    }
                    Console.WriteLine();

                    // Total book by condition
                    Dictionary<BookCondition, int> summaryByCondition = Processing.CountByCondition(Books);

                    // Top 5 book by penalty with Title, Author, TotalPenalty
                    List<string> topFivePenaltyBooks = Processing.TopFivePenaltyBook(Books);

                    // Content to write in report
                    string contentOfReport = Processing.GenerateReportContent(DateTime.Now, Books.Count, summaryByCondition, topFivePenaltyBooks);

                    // File name of report
                    string reportFileName = $"daily_summary_{DateTime.Now.ToString("yyyyMMdd")}.txt";

                    // Store report at ./out/daily_summary_date.txt
                    string reportFilePath = Path.Combine(".\\out", reportFileName);

                    // Write report content to .txt file
                    IOHandler.writeFile(reportFilePath, contentOfReport);

                    Console.WriteLine($"Report saved at {reportFilePath}");
                }
                else
                {
                    throw new Exception("Cound not read file");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("\n\nAn error occurred:: " + ex.Message);
            }
        }
    }
}
