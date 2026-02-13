using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PolymorphismDemo
{
    [JsonPolymorphic]
    [JsonDerivedType(typeof(Inova), "Inova")]
    public class Car : Vehicle
    {
        public string Name { get; set; }
        public string Company { get; set; }
    }
}
