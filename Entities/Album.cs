public class Album
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public string Name { get; set; } = string.Empty;
    public List<Image> Images { get; set; } = new();
}