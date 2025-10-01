using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Ingestion.Pipeline.Report
{
    public class JsonReportWriter : IReportWriter<Report>
    {
        public void Write(Report report)
        {
            string jsonReport = JsonSerializer.Serialize(report, new JsonSerializerOptions
            {
                WriteIndented = true,
            });

            string reportPath = "./out/report.json";

            using (StreamWriter writer = new StreamWriter(reportPath))
            {
                writer.Write(jsonReport);
            }

            Console.WriteLine($"Report written at {reportPath}");
        }
    }
}
