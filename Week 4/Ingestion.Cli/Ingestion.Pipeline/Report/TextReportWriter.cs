using Ingestion.Pipeline.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingestion.Pipeline.Report
{
    /// <summary>
    /// A class to write report in plain text format.
    /// </summary>
    public class TextReportWriter : IReportWriter<Report>
    {
        /// <summary>
        /// A method to write report in plain text format.
        /// </summary>
        /// <param name="report">Report which will be written to file</param>
        public void Write(Report report)
        {
            // Build the report content as a string
            StringBuilder content = new ();

            content.AppendLine($"Processing Time: {report.ProcessingTime}");

            content.AppendLine();

            content.AppendLine($"Total Books Processed: {report.TotalBooksProcessed}");

            content.AppendLine();

            content.AppendLine("Book Condition Counts:");
            foreach (Domain.BookCondition key in report.ConditionCounts.Keys)
            {
                content.AppendLine($"  {key}: {report.ConditionCounts[key]}");
            }

            content.AppendLine();

            content.AppendLine($"Top {report.TopProblematicBooks.Count} Problematic Books:");
            foreach(BookSummary book in report.TopProblematicBooks)
            {
                content.AppendLine($"  Id: {book.Id}, Title: {book.Title}, Author: {book.Author}, Total Penalty: {book.TotalPenalty}");
            }

            // Extract string to write
            string reportContent = content.ToString();

            // Path where report will be written
            string reportPath = "./out/report.txt";

            using (StreamWriter writer = new StreamWriter(reportPath))
            {
                writer.Write(reportContent);
            }

            Console.WriteLine($"Report written at {reportPath}");
        }
    }
}
