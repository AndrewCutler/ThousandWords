public class GetImageDTO
{
    public Guid Id { get; init; }
    public string ImageData { get; init; } = string.Empty;
    public Guid UserId { get; init; }
    public bool Active { get; init; } = true;
    public string? Link { get; init; }
    public DateTime UploadDate { get; init; }

    public GetImageDTO(Image sourceEntity)
    {
        this.Id = sourceEntity.Id;
        this.ImageData = sourceEntity.ImageData;
        this.UserId = sourceEntity.UserId;
        this.Active = sourceEntity.Active;
        this.Link = sourceEntity.Link;
        this.UploadDate = sourceEntity.UploadDate;
    }
}