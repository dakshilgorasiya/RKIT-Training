using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingestion.Pipeline.DTO
{
    /// <summary>
    /// Used to process unique book summary information, including total penalty.
    /// </summary>
    public class BookSummary:Book
    {
        /// <summary>
        /// Represent the total penalty associated with the unique book.
        /// </summary>
        public int TotalPenalty { get; set; }
    }
}
