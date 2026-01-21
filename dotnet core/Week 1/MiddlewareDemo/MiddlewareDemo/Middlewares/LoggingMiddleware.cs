namespace MiddlewareDemo.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine($"Logging middleware Incoming request : {context.Request.Method} {context.Request.Path}");

            await _next(context);

            Console.WriteLine($"Logging middleware outgoing request : {context.Response.StatusCode}");
        }
    }

    public static class LoggingMiddlewareExtension
    {
        public static IApplicationBuilder UseLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }
}
