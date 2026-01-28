using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SourceGeneratorDemo
{
    [JsonSerializable(typeof(User))]
    public partial class AppJsonContext: JsonSerializerContext
    {
    }
}
