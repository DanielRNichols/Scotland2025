using Scotland2025.Application.Common.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Scotland2025.Extensions;

namespace Scotland2025.Errors;

public static class ErrorsEndpoints
{
    public static void MapErrorsEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.Map("/error", (HttpContext context) =>
        {
            var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
            if (exception != null)
            {
                return TypedResults.Problem();
            }

            return exception switch
            {
                ServiceException serviceException => TypedResults.Problem(statusCode: serviceException.ToHttpStatusCode(), detail: serviceException.ErrorMessage),
                _ => TypedResults.Problem()
            };

        });

    }

}
