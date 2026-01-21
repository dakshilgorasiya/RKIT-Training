namespace DependencyInjectionDemo.Services
{
    public class UserService : IUserService
    {
        private readonly Guid _id = Guid.NewGuid();
        public List<string> GetUsers()
        {
            Console.WriteLine($"User service {_id}");
            return new List<string> { "Dakshil", "Manish", "Hemang", "Nisharg" };
        }
    }
}
