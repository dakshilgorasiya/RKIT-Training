using Microsoft.AspNetCore.Http;
using NLog;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MiddlewareDemo.Middlewares
{
    public class NLogMiddleware
    {
        private static readonly NLog.ILogger _logger = LogManager.GetCurrentClassLogger();

        private readonly RequestDelegate _next;

        public NLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var sw = Stopwatch.StartNew();

            await _next(context);

            sw.Stop();
            _logger.Info("Request: {method} {url} => {status} in {ms}ms",
                context.Request.Method,
                context.Request.Path,
                context.Response.StatusCode,
                sw.ElapsedMilliseconds);
        }
    }
}
