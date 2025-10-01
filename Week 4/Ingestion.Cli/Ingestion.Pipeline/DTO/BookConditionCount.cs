using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ingestion.Pipeline.DTO
{
    /// <summary>
    /// Used to proxy the count of books by their condition for XML serialization.
    /// </summary>
    public class BookConditionCount
    {
        /// <summary>
        /// Represents the condition of the book (e.g., New, Used, etc.).
        /// </summary>
        [XmlAttribute("Condition")]
        public BookCondition Condition { get; set; }

        /// <summary>
        /// Represents the count of books in the specified condition.
        /// </summary>
        [XmlElement("Count")]
        public int Count { get; set; }
    }
}
