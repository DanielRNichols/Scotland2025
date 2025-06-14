namespace Scotland2025.Contracts.Images;
public static class UpdateImage
{
    public record Request(string Url, string? Description, DateTime? DateAdded, string? AddedBy);

    public record Response(int Id, string Url, string? Description, DateTime? DateAdded, string? AddedBy);
}
