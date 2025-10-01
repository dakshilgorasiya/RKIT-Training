using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ingestion.Pipeline.Report
{
    /// <summary>
    /// A class to write report in XML format.
    /// </summary>
    public class XmlReportWriter : IReportWriter<Report>
    {
        /// <summary>
        /// A method to write report in XML format.
        /// </summary>
        /// <param name="report"></param>
        public void Write(Report report)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Report));

            // Path where report will be written
            string reportPath = "./out/report.xml";

            using (StreamWriter writer = new StreamWriter(reportPath))
            {
                xmlSerializer.Serialize(writer, report);
            }

            Console.WriteLine($"Report written at {reportPath}");
        }
    }
}
