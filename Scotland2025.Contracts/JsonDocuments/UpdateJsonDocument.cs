namespace Scotland2025.Contracts.JsonDocuments;
public static class UpdateJsonDocument
{
    public record Request(string JsonValue);

    public record Response(int Id, string DocumentName, string JsonValue, DateTime LastModified);


}
