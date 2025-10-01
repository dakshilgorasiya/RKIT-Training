using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace DataSerilization
{
    public class Address
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
    public enum Grade
    {
        A, B, C, D, F
    }
    public class Student
    {
        [JsonPropertyName("StudentId")]
        [Newtonsoft.Json.JsonProperty("StudentId")]
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public int Age { get; set; }
        internal string Secret { get; set; }
        public Address Address { get; set; }
        public Grade Grade { get; set; }
    }
    internal class JSON
    {
        static void Main(string[] args)
        {
            Student student = new Student
            {
                Id = 1,
                Name = "John Doe",
                Age = 20,
                Secret = "HI",
                Address = new Address
                {
                    City = "New York",
                    State = "NY",
                    Country = "USA"
                },
                Grade = Grade.A
            };

            // By default all public properties are serialized
            string jsonStudent1 = JsonSerializer.Serialize(student);
            //string jsonStudent2 = JsonSerializer.Serialize<Student>(student);
            Console.WriteLine(jsonStudent1);

            Student student2 = JsonSerializer.Deserialize<Student>(jsonStudent1);
            Console.WriteLine($"Id: {student2.Id}, Name: {student2.Name}, Age: {student2.Age}, Secret: {student2.Secret}, Grade: {student2.Grade}");

            // WriteIndented option for pretty print
            string jsonStudent3 = JsonSerializer.Serialize(student, new JsonSerializerOptions
            {
                WriteIndented = true,
            });
            Console.WriteLine(jsonStudent3);


            // To store enum as string instead of integer
            string jsonStudent4 = JsonSerializer.Serialize(student, new JsonSerializerOptions
            {
                Converters =
                {
                    new JsonStringEnumConverter()
                }
            });
            Console.WriteLine(jsonStudent4);




            // Newtonsoft.Json example
            string jsonStudent5 = Newtonsoft.Json.JsonConvert.SerializeObject(student, Newtonsoft.Json.Formatting.Indented, new Newtonsoft.Json.JsonSerializerSettings
            {
                Converters =
                {
                    new Newtonsoft.Json.Converters.StringEnumConverter()
                }
            });
            Console.WriteLine(jsonStudent5);
            

            Student student3 = Newtonsoft.Json.JsonConvert.DeserializeObject<Student>(jsonStudent5);
            Console.WriteLine(student3.Id + " " + student3.Name);
        }
    }
}
