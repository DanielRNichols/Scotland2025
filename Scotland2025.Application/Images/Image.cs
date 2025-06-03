namespace Scotland2025.Application.Images;
public class Image
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string ThumbnailUrl { get; set; } = string.Empty;
    public string FullUrl { get; set; } = string.Empty;
    public string MediumUrl { get; set; } = string.Empty;
    public string UploadedBy { get; set; } = string.Empty;
    public DateTime UploadedAt { get; set; } = DateTime.MinValue;
}
