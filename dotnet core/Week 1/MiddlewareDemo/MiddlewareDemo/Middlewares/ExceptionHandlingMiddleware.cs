using NLog;
using System.Net;
using System.Text.Json;

namespace MiddlewareDemo.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private static readonly NLog.ILogger _logger = LogManager.GetCurrentClassLogger();

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.Error(exception.StackTrace, "Unhandled exception occurred while processing request");

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var result = JsonSerializer.Serialize(new
            {
                error = "Something went wrong. Please try again later.",
                details = exception.Message
            });

            return context.Response.WriteAsync(result);
        }
    }
}
