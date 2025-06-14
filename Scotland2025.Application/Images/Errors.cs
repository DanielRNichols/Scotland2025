using ErrorOr;

namespace Scotland2025.Application.Images;

public static partial class ApplicationErrors
{
    public static class Images
    {
        public static Error NotFound(int id) =>
            Error.NotFound(
                code: "Images.NotFound",
                description: $"Image with id = {id} was not found.");

        public static Error NotFound(string url) =>
            Error.NotFound(
                code: "Images.NotFound",
                description: $"Image with url = {url} was not found.");

        public static Error Conflict(string url) =>
            Error.Conflict(
                code: "Images.Conflict",
                description: $"Image with url = {url} already exists.");

    }
}