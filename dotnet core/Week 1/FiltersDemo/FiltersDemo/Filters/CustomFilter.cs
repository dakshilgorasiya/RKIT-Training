using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersDemo.Filters
{
    public class CustomFilter : IFilterMetadata
    {
        private readonly string _message;

        public CustomFilter(string message)
        {
            _message = message;
        }

        public void Execute()
        {
            Console.WriteLine(_message);
        }
    }
}
