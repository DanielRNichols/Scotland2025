using ErrorOr;

namespace Scotland2025.Application.JsonDocuments;

public static partial class ApplicationErrors
{
    public static class JsonDocuments
    {
        public static Error NotFound(int id) =>
            Error.NotFound(
                code: "JsonDocuments.NotFound",
                description: $"JsonDocument with id = {id} was not found.");

        public static Error NotFound(string documentName) =>
            Error.NotFound(
                code: "JsonDocuments.NotFound",
                description: $"JsonDocument with name = {documentName} was not found.");

        public static Error Conflict(string name) =>
            Error.Conflict(
                code: "JsonDocuments.Conflict",
                description: $"JsonDocument with DocumentName = {name} already exists.");

    }
}