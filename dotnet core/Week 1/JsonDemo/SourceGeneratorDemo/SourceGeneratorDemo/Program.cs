using System.Text.Json;

namespace SourceGeneratorDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User()
            {
                Id = 1,
                Name = "Test",
            };

            //string json = JsonSerializer.Serialize(user, AppJsonContext.Default.User);

            //Console.WriteLine(json);
        }
    }
}