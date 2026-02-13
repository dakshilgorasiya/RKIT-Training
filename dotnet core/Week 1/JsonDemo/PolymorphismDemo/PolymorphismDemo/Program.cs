using System.Text.Json;
using System.Text.Json.Serialization;

namespace PolymorphismDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Vehicle vehicle = new Car()
            //{
            //    ManufacturingYear = 1990,
            //    Name = "Inova",
            //    Company = "Toyota"
            //};

            //string jsonString = JsonSerializer.Serialize(vehicle);

            //Console.WriteLine(jsonString);

            //Car jsonObject = JsonSerializer.Deserialize<Car>(jsonString);
            //Console.WriteLine($"{jsonObject.ManufacturingYear}, {jsonObject.Name}, {jsonObject.Company}");

            Car vehicle = new Inova()
            {
                ManufacturingYear = 2009,
                Company = "Toyota",
                Name = "Inova",
                engineSize = 4000
            };

            string jsonString = JsonSerializer.Serialize(vehicle);
            Console.WriteLine(jsonString);

            Inova jsonObject = JsonSerializer.Deserialize<Inova>(jsonString);
            Console.WriteLine($"{jsonObject.ManufacturingYear}, {jsonObject.Name}, {jsonObject.Company}, {jsonObject.engineSize}");
        }
    }
}