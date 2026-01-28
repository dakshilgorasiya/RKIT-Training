using System.Text;
using System.Text.Json;

namespace UTF8Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var stream = new MemoryStream();
            var writer = new Utf8JsonWriter(stream, new JsonWriterOptions
            {
                Indented = true,
            });

            writer.WriteStartObject();

            writer.WriteNumber("id", 1);
            writer.WriteString("name", "Dakshil");

            writer.WriteStartArray("skills");
            writer.WriteStringValue("C#");
            writer.WriteStringValue(".NET");
            writer.WriteStringValue("ASP.NET Core");
            writer.WriteEndArray();

            writer.WriteStartObject("address");
            writer.WriteString("street", "a");
            writer.WriteString("city", "b");
            writer.WriteString("state", "c");
            writer.WriteEndObject();

            writer.WriteEndObject();

            writer.Flush();

            string json = Encoding.UTF8.GetString(stream.ToArray());
            Console.WriteLine(json);

            ReadOnlySpan<byte> data = Encoding.UTF8.GetBytes(json);
            var reader = new Utf8JsonReader(data);

            User user = new User();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    string propName = reader.GetString();

                    reader.Read();

                    switch (propName)
                    {
                        case "id":
                            user.Id = reader.GetInt32();
                            break;

                        case "name":
                            user.Name = reader.GetString();
                            break;

                        case "skills":
                            if (reader.TokenType == JsonTokenType.StartArray)
                            {
                                var skills = new List<string>();
                                while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                                {
                                    skills.Add(reader.GetString());
                                }
                                user.Skills = skills;
                            }
                            break;

                        case "address":
                            if (reader.TokenType == JsonTokenType.StartObject)
                            {
                                Address address = new Address();

                                while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
                                {
                                    if (reader.TokenType == JsonTokenType.PropertyName)
                                    {
                                        string innerPropName = reader.GetString();
                                        reader.Read(); // move to value

                                        switch (innerPropName)
                                        {
                                            case "street":
                                                address.Street = reader.GetString();
                                                break;
                                            case "city":
                                                address.City = reader.GetString();
                                                break;
                                            case "state":
                                                address.State = reader.GetString();
                                                break;
                                        }
                                    }
                                }

                                user.Address = address; // assign to user after reading all fields
                            }
                            break;

                    }
                }
            }

            Console.WriteLine(user.ToString());
        }
    }
}