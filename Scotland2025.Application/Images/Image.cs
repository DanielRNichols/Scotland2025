namespace Scotland2025.Application.Images;
public class Image
{
    public int Id { get; set; }
    public string Url { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime? DateAdded { get; set; }
    public string? AddedBy { get; set; }

    public static Image Create(string url, string? description, DateTime? dateAdded, string? addedBy)
    {
        return new Image { Url = url, Description = description, DateAdded = dateAdded, AddedBy = addedBy };
    }

    public static Image Create(int id, string url, string? description, DateTime? dateAdded, string? addedBy)
    {
        return new Image { Id = id, Url = url, Description = description, DateAdded = dateAdded, AddedBy = addedBy };
    }
}
