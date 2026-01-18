using NLog;
using System.Web.Http.Filters;

public class GlobalExceptionFilter : ExceptionFilterAttribute
{
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();

    public override void OnException(HttpActionExecutedContext context)
    {
        // Log the exception details
        logger.Error(context.Exception, "Unhandled exception");
    }
}
