using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;

namespace DynamicTypePractise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            dynamic val = 5;
            Console.WriteLine(val.GetType()); // System.Int32
            Console.WriteLine(val + 5); // 5

            val = "Hello, ";
            Console.WriteLine(val.GetType()); // System.String
            Console.WriteLine(val + "World!"); // Hello, World!

            try
            {
                val = 10;
                val = val.ToUpper(); // This will throw a RuntimeBinderException
            }
            catch(RuntimeBinderException ex)
            {
                Console.WriteLine(ex.Message);
            }




            // Using dynamic with JSON
            string jsonString = @"{
              'user': { 'id': 123, 'name': 'Alex', 'roles': ['Admin', 'Editor'] },
              'lastLogin': '2025-10-15T14:30:00Z'
            }";

            dynamic jsonObj = JsonConvert.DeserializeObject<dynamic>(jsonString);
            Console.WriteLine($"User ID: {jsonObj.user.id}");
            Console.WriteLine($"User Name: {jsonObj.user.name}");
            Console.WriteLine($"First Role: {jsonObj.user.roles[0]}");

            try
            {
                Console.WriteLine(jsonObj.user.nonExistentProperty); // This will throw a RuntimeBinderException
            }
            catch(RuntimeBinderException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
