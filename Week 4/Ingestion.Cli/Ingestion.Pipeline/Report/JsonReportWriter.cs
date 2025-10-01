using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Ingestion.Pipeline.Report
{
    /// <summary>
    /// Class to write report in JSON format.
    /// </summary>
    public class JsonReportWriter : IReportWriter<Report>
    {
        /// <summary>
        /// Method to write report in JSON format.
        /// </summary>
        /// <param name="report">Report which will be written to file</param>
        public void Write(Report report)
        {
            // Serialize the report object to JSON format with indentation for readability
            string jsonReport = JsonSerializer.Serialize(report, new JsonSerializerOptions
            {
                WriteIndented = true,
            });

            // Define the path where the report will be saved
            string reportPath = "./out/report.json";

            // Write the JSON report to the specified file
            using (StreamWriter writer = new StreamWriter(reportPath))
            {
                writer.Write(jsonReport);
            }

            Console.WriteLine($"Report written at {reportPath}");
        }
    }
}
