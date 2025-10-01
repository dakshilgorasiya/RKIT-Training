using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataSerilization
{
    internal class XML
    {
        static void Main(string[] args)
        {
            Student student1 = new Student
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

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Student));
            using (StringWriter stringWriter = new StringWriter())
            {
                xmlSerializer.Serialize(stringWriter, student1);
                string xmlStudent = stringWriter.ToString();
                Console.WriteLine(xmlStudent);
                using (StringReader stringReader = new StringReader(xmlStudent))
                {
                    Student student2 = (Student)xmlSerializer.Deserialize(stringReader);
                    Console.WriteLine($"Id: {student2.Id}, Name: {student2.Name}, Age: {student2.Age}, Secret: {student2.Secret}, Grade: {student2.Grade}");
                }
            }
        }
    }
}
