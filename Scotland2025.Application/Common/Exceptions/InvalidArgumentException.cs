using Scotland2025.Application.Common.Errors;

namespace Scotland2025.Application.Common.Exceptions;
public class InvalidArgumentException : ServiceException
{
    public InvalidArgumentException(string message) : base(ErrorCodes.InvalidArgument, message)
    {

    }

}
