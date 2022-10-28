public class Image
{
    public Guid Id { get; init; }
    public string ImageData { get; init; } = string.Empty;
    public Guid UserId { get; init; }
    public bool Active { get; set; } = true;
    public string? Link { get; init; }
    public DateTime UploadDate { get; init; }
}