using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingestion.Pipeline.Report
{
    public interface IReportWriter<T>
    {
        void Write(T report);
    }
}
