public class Image
{
    public Guid Id { get; init; }
    public string ImageData { get; init; } = string.Empty;
    public Guid UserId { get; init; }
    public bool Active { get; set; } = true;
    public Link? Link { get; set; }
    public DateTime Created { get; init; }
}