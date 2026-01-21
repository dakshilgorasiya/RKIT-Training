namespace DependencyInjectionDemo.Services
{
    public class EmailService : IEmailService
    {
        private readonly Guid _id = Guid.NewGuid();
        public void Send(string message)
        {
            Console.WriteLine($"Email instance {_id} : {message}");
        }
    }
}
