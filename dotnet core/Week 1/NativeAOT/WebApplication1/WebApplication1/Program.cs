using System.Diagnostics;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var stopwatch = Stopwatch.StartNew();

            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            stopwatch.Stop();
            Console.WriteLine($"Startup time: {stopwatch.ElapsedMilliseconds} ms");

            app.MapGet("/ping", () => "pong");

            app.Run();
        }
    }
}