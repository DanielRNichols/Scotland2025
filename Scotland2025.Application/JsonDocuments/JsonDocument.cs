using Scotland2025.Application.Common.Exceptions;

namespace Scotland2025.Application.JsonDocuments;

public class JsonDocument
{
    public int Id { get; private set; }
    public string DocumentName { get; private set; } = string.Empty;
    public string JsonValue { get; private set; } = string.Empty;
    public DateTime LastModified { get; private set; } = DateTime.MinValue;
    private JsonDocument() { }

    private JsonDocument(int id, string documentName, string jsonValue, DateTime lastModified)
    {
        Id = id;
        DocumentName = documentName;
        JsonValue = jsonValue;
        LastModified = lastModified;
    }

    private JsonDocument(string documentName, string jsonValue, DateTime lastModified)
    {
        DocumentName = documentName;
        JsonValue = jsonValue;
        LastModified = lastModified;
    }

    internal static JsonDocument Create(int id, string documentName, string jsonValue, DateTime lastModified)
    {
        var jsondocument = Create(documentName, jsonValue, lastModified);
        if (id < 0)
        {
            throw new InvalidArgumentException("JsonDocument Id must be non-negative.");
        }
        jsondocument.Id = id;
        return jsondocument;
    }

    public static JsonDocument Create(string documentName, string jsonValue, DateTime lastModified)
    {
        if (string.IsNullOrWhiteSpace(documentName))
        {
            throw new InvalidArgumentException("JsonDocument name cannot be empty.");
        }
        return new JsonDocument(documentName.ToLower(), jsonValue, lastModified);
    }

}
