namespace Scotland2025.Api.Filters;

public class IdValidationFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var id = context.GetArgument<int>(0);
        if (id <= 0)
        {
            var errors = new Dictionary<string, string[]>()
            {
                { "InvalidId", [ "Id must be greater than 0" ] }
            };
            return TypedResults.ValidationProblem(errors);
        }

        return await next(context);
    }
}
