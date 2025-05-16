namespace Scotland2025.Application.Abstractions.DatesAndTime;
public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
    DateTime Now { get; }
}
