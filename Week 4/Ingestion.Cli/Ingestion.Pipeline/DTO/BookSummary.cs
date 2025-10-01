using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingestion.Pipeline.DTO
{
    public class BookSummary:Book
    {
        public int TotalPenalty { get; set; }
    }
}
