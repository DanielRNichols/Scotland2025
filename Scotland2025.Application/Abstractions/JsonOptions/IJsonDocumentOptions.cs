using System.Text.Json;

namespace Scotland2025.Application.Abstractions.JsonOptions;
public interface IJsonDocumentOptions
{
    JsonSerializerOptions JsonSerializerOptions { get; }
}
