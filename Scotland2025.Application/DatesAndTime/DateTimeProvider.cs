using Scotland2025.Application.Abstractions.DatesAndTime;

namespace Scotland2025.Infrastructure.DatesAndTime;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
    public DateTime Now => DateTime.Now;
}
