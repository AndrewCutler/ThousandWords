public class Image
{
    public Guid Id { get; init; }
    public string ImageData { get; init; } = string.Empty;
    public Guid UserId { get; init; }
    public bool Active { get; init; } = true;
    public string Link { get; init; } = string.Empty;
    public DateTime UploadDate { get; init; }
}