using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Xml.Serialization;
using Ingestion.Pipeline.DTO;
using System.Text.Json.Serialization;

namespace Ingestion.Pipeline.Report
{
    /// <summary>
    /// A class representing a report of processed books.
    /// </summary>
    public class Report
    {
        /// <summary>
        /// The time when the report was generated.
        /// </summary>
        public DateTime ProcessingTime { get; set; }

        /// <summary>
        /// Total number of books processed.
        /// </summary>
        public int TotalBooksProcessed { get; set; }

        /// <summary>
        /// Total number of book by condition
        /// </summary>

        [XmlIgnore]
        public Dictionary<BookCondition, int> ConditionCounts { get; set; }

        /// <summary>
        /// Top books with highest penalty.
        /// </summary>
        [XmlArrayItem("Book")]
        public List<DTO.BookSummary> TopProblematicBooks { get; set; }

        /// <summary>
        /// A proxy property for XML serialization of ConditionCounts.
        /// </summary>

        [XmlArray("BookConditionCounts")]
        [XmlArrayItem("Condition")]
        [JsonIgnore]
        public List<BookConditionCount> ConditionCountProxy
        {
            get
            {
                return ConditionCounts.Select(kvp => new BookConditionCount
                {
                    Condition = kvp.Key,
                    Count = kvp.Value
                }).ToList();
            }
            set
            {
                ConditionCounts = value.ToDictionary(item => item.Condition, item => item.Count);
            }
        }
    }
}
