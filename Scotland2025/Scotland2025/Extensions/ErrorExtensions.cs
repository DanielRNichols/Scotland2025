using ErrorOr;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Scotland2025.Extensions;

public static class ErrorExtensions
{
    public static ProblemHttpResult ToProblemHttpResult(this List<Error> errors)
    {
        if (!errors.Any())
            return TypedResults.Problem();

        //if (errors.All(e => e.Type == ErrorType.Validation))
        //    return ValidationProblem(errors);

        return Problem(errors[0]);

    }

    private static ProblemHttpResult Problem(Error error)
    {
        var statusCode = error.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError,
        };

        //if (error == Errors.Authentication.InvalidCredentials)
        //    statusCode = StatusCodes.Status401Unauthorized;

        return TypedResults.Problem(statusCode: statusCode, title: error.Code, detail: error.Description);
    }


}
