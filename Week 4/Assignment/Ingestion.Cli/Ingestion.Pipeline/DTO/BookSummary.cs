using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Text.Json.Serialization;

namespace Ingestion.Pipeline.DTO
{
    /// <summary>
    /// Used to process unique book summary information, including total penalty.
    /// </summary>
    /// Sealed because BookSUmmary is a DTO and not intended to extend
    public sealed class BookSummary
    {
        /// <summary>
        /// Represent unique Id of book
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Represent title of book
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Represent author of book
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Represent the total penalty associated with the unique book.
        /// </summary>
        public int TotalPenalty { get; set; }
    }
}
