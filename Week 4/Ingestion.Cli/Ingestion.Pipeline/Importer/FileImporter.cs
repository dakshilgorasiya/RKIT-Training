using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingestion.Pipeline.Importer
{
    public abstract class FileImporter<T>
    {
        public abstract IEnumerable<T> Import(string filePath);
    }
}
