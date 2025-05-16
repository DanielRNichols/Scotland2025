using Scotland2025.Application.Common.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace Scotland2025.Api.Extensions;

public static class WebApplicationExtensions
{
    public static void UseGlobalErrorHandling(this WebApplication app)
    {
        app.UseExceptionHandler("/error");

        app.Map("/error", (HttpContext context) =>
        {
            var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
            if (exception is null) 
            {
                return TypedResults.Problem();
            }

            return exception switch
            {
                ServiceException serviceException => 
                        TypedResults.Problem(statusCode: serviceException.ToHttpStatusCode(), detail: serviceException.ErrorMessage),
                _ => TypedResults.Problem()
            };
        });
    }
}
