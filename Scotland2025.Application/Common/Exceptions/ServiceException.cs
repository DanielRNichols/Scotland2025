namespace Scotland2025.Application.Common.Exceptions;
public class ServiceException : Exception
{
    public string ErrorCode { get; set; } = string.Empty;
    public string ErrorMessage { get; set; } = string.Empty;
    public ServiceException(string code, string message) : base(message)
    {
        ErrorCode = code;
        ErrorMessage = message;
    }
}
