using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations
{
    /// <summary>
    /// A custom JSON converter for DateTimeOffset to handle specific serialization and deserialization formats.
    /// </summary>
    public class CustomDateTimeOffsetConverter : JsonConverter
    {
        /// <summary>
        /// Custom date-time format including timezone information.
        /// </summary>
        private const string Format = "yyyy-MM-dd HH:mm:ss zzz";

        /// <summary>
        /// A method to determine if the converter can handle the specified object type.
        /// </summary>
        /// <param name="objectType">A type of object to check</param>
        /// <returns>A boolean indicating if the type is DateTimeOffset</returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTimeOffset);
        }

        /// <summary>
        /// A method to read and convert JSON data to a DateTimeOffset object.
        /// </summary>
        /// <param name="reader">Reader to read JSON data</param>
        /// <param name="objectType">object type to convert to</param>
        /// <param name="existingValue">Existing value of the object being read</param>
        /// <param name="serializer">Serializer to use for conversion</param>
        /// <returns>object of DateTimeOffset type or null if conversion fails</returns>
        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (reader.Value is string dateString)
            {
                return DateTimeOffset.ParseExact(dateString, Format, CultureInfo.InvariantCulture);
            }
            return null;
        }

        /// <summary>
        /// A method to write a DateTimeOffset object to JSON using the specified format.
        /// </summary>
        /// <param name="writer">Writer to write JSON data</param>
        /// <param name="value">object value to write</param>
        /// <param name="serializer">Serializer to use for conversion</param>
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value is DateTimeOffset dateTimeOffset)
            {
                writer.WriteValue(dateTimeOffset.ToString(Format));
            }
        }
    }
}
