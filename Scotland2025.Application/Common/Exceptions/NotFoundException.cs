using Scotland2025.Application.Common.Errors;
using System.Net;

namespace Scotland2025.Application.Common.Exceptions;
public class NotFoundException : ServiceException
{
    public NotFoundException(string message) : base(ErrorCodes.NotFound, message)
    {
        
    }
}
