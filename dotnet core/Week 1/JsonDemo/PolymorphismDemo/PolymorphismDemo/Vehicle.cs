using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PolymorphismDemo
{
    [JsonPolymorphic]
    [JsonDerivedType(typeof(Car), "car")]
    [JsonDerivedType(typeof(Inova), "inova")]
    public class Vehicle
    {
        public int ManufacturingYear { get; set; }
    }
}
