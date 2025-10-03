using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingestion.Pipeline.Importer
{
    /// <summary>
    /// Abstract base class for importing data from files.
    /// </summary>
    /// <typeparam name="T">Type of object to which data will be parsed</typeparam>
    public abstract class FileImporter<T>
    {
        public abstract IEnumerable<T> Import(string filePath);
    }
}
