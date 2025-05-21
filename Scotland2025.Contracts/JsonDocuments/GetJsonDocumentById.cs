namespace Scotland2025.Contracts.JsonDocuments;
public static class GetJsonDocumentById
{
    public record Response(int Id, string DocumentName, string JsonValue, DateTime LastModified);

}
