using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingestion.Pipeline.Report
{
    /// <summary>
    /// A interface to write report to a file.
    /// </summary>
    /// <typeparam name="T">Type of object which will be serialized and written in file</typeparam>
    public interface IReportWriter<T>
    {
        void Write(T report);
    }
}
