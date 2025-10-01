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
    public class Report
    {
        public DateTime ProcessingTime { get; set; }
        public int TotalBooksProcessed { get; set; }

        [XmlIgnore]
        public Dictionary<BookCondition, int> ConditionCounts { get; set; }
        public List<DTO.BookSummary> TopProblematicBooks { get; set; }

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
