using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ingestion.Pipeline.DTO
{
    public class BookConditionCount
    {
        [XmlAttribute("Condition")]
        public BookCondition Condition { get; set; }

        [XmlElement("Count")]
        public int Count { get; set; }
    }
}
