using MiniValidation;

namespace MinimalAPIDemo.Filters
{
    public class GlobalValidationFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            foreach(var arg in context.Arguments)
            {
                if (arg is null) continue;

                if (!MiniValidator.TryValidate(arg, out var errors))
                {
                    return Results.ValidationProblem(errors);
                }
            }

            return await next(context);
        }
    }
}
