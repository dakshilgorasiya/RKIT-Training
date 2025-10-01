using Domain;
using Ingestion.Pipeline.Extension;
using Ingestion.Pipeline.Importer;
using Ingestion.Pipeline.Report;
using Ingestion.Pipeline.DTO;

namespace Ingestion.Cli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Flag to indicate whether to perform a dry run (no file processing)
            bool IsDryRun = args.Contains("--dry-run");

            if(IsDryRun)
            {
                Console.WriteLine("Dry run mode enabled. No file will be processed");
            }

            // Set the current directory to the project root
            string root = AppContext.BaseDirectory;
            string projectRoot = Path.Combine(root, @"../../../");
            Directory.SetCurrentDirectory(projectRoot);

            // Locate all CSV and JSON files in the "in" directory and its subdirectories
            DirectoryInfo dataDirectory = new DirectoryInfo("./in");
            FileInfo[] csvFiles = dataDirectory.GetFiles("*.csv", SearchOption.AllDirectories);
            FileInfo[] jsonFiles = dataDirectory.GetFiles("*.json", SearchOption.AllDirectories);

            // Display the names of the files that will be processed
            Console.WriteLine($"Total files found: {csvFiles.Length + jsonFiles.Length}");
            Console.WriteLine("Following file would be processed:");
            foreach (FileInfo file in csvFiles)
            {
                Console.WriteLine($"{file.Name}");
            }
            foreach(FileInfo file in jsonFiles)
            {
                Console.WriteLine($"{file.Name}");
            }

            // If dry run mode is enabled, exit without processing files
            if (IsDryRun)
            {
                return;
            }

            // Used to store all book data from all files
            List<Book> returnBookData = new List<Book>();

            // Importers for CSV and JSON files
            CsvBookImporter csvBookImporter = new CsvBookImporter();
            JsonBookImporter jsonBookImporter = new JsonBookImporter();

            // Process each CSV file and aggregate the book data
            foreach (FileInfo file in csvFiles)
            {
                List<Book> books = csvBookImporter.Import(file.FullName).ToList();
                returnBookData.AddRange(books);
            }

            // Process each JSON file and aggregate the book data
            foreach (FileInfo file in jsonFiles)
            {
                List<Book> books = jsonBookImporter.Import(file.FullName).ToList();
                returnBookData.AddRange(books);
            }

            Console.WriteLine($"\n\nTotal {returnBookData.Count} book entries found\n\n");

            Dictionary<BookCondition, int> conditionCount = returnBookData.ToConditionCounts();
            

            List<BookSummary> top3PenaltyBooks = returnBookData.TopBy(BookExtension.GetPenalty, 3);

            Report report = new Report
            {
                ProcessingTime = DateTime.Now,
                TotalBooksProcessed = returnBookData.Count,
                ConditionCounts = conditionCount,
                TopProblematicBooks = top3PenaltyBooks
            };

            IReportWriter<Report> textReportWriter = new TextReportWriter();
            IReportWriter<Report> xmlReportWriter = new XmlReportWriter();
            IReportWriter<Report> jsonReportWriter = new JsonReportWriter();

            textReportWriter.Write(report);
            xmlReportWriter.Write(report);
            jsonReportWriter.Write(report);
        }
    }
}
