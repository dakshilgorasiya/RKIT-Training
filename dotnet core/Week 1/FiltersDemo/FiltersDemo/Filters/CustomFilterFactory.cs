using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersDemo.Filters
{
    public class CustomFilterFactory : IFilterFactory
    {
        private readonly string _message;
        public CustomFilterFactory(string message)
        {
            _message = message;
        }
        public bool IsReusable => false;

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return new CustomFilter(_message);
        }
    }
}
