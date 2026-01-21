using System.Security.Cryptography;

namespace DependencyInjectionDemo.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly Guid _id = Guid.NewGuid();
        public string AppName
        {
            get
            {
                Console.WriteLine($"Setting service {_id}");
                return "MyApp";
            }
        }
    }
}
