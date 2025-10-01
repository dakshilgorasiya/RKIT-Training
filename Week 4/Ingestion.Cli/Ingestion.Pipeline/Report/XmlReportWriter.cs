using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ingestion.Pipeline.Report
{
    public class XmlReportWriter : IReportWriter<Report>
    {
        public void Write(Report report)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Report));

            string reportPath = "./out/report.xml";

            using (StreamWriter writer = new StreamWriter(reportPath))
            {
                xmlSerializer.Serialize(writer, report);
            }
            Console.WriteLine($"Report written at {reportPath}");
        }
    }
}
