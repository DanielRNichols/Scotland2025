namespace Scotland2025.Contracts.JsonDocuments;
public static class GetJsonDocumentByName
{
    public record Response(int Id, string DocumentName, string JsonValue, DateTime LastModified);
}
