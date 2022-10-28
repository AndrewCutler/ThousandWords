public class GetImageDTO
{
    public Guid Id { get; init; }
    public string ImageData { get; init; } = string.Empty;
    public Guid UserId { get; init; }
    public bool Active { get; init; } = true;
    public string? Url { get; init; }
    public DateTime UploadDate { get; init; }

    public GetImageDTO(Image sourceEntity)
    {
        this.Id = sourceEntity.Id;
        this.ImageData = sourceEntity.ImageData;
        this.UserId = sourceEntity.UserId;
        this.Active = sourceEntity.Active;
        // TODO: replace with real domain
        this.Url = sourceEntity.Link is not null ? $"https://test.com/image?id={sourceEntity.Link.Id}" : null;
        this.UploadDate = sourceEntity.Created;
    }
}