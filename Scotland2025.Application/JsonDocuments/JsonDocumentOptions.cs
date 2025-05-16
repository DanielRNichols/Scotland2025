using Scotland2025.Application.Abstractions.JsonOptions;
using System.Text.Json;

namespace Scotland2025.Application.JsonDocuments;
public class JsonDocumentOptions : IJsonDocumentOptions
{
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public JsonDocumentOptions()
    {
        _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }

    public JsonSerializerOptions JsonSerializerOptions => _jsonSerializerOptions;
}
