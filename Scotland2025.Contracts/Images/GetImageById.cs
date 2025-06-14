namespace Scotland2025.Contracts.Images;
public static class GetImageById
{
    public record Response(int Id, string Url, string? Description, DateTime? DateAdded, string? AddedBy);

}
