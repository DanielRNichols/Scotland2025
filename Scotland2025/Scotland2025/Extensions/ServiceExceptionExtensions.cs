using Scotland2025.Application.Common.Exceptions;

namespace Scotland2025.Api.Extensions;

public static class ServiceExceptionExtensions
{
    public static int? ToHttpStatusCode(this ServiceException serviceException)
    {
        return serviceException.ErrorCode switch
        {
            "NotFound" => StatusCodes.Status404NotFound,
            "BadRequest" => StatusCodes.Status400BadRequest,
            "Forbidden" => StatusCodes.Status403Forbidden,
            "Unauthorized" => StatusCodes.Status401Unauthorized,
            "Conflict" => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError
        };
    }

}
