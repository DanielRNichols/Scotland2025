namespace Scotland2025.Contracts.JsonDocuments;
public static class CreateJsonDocument
{
    public record Request(string DocumentName, string JsonValue);

    public record Response(int Id, string DocumentName, string JsonValue, DateTime LastModified);
}
