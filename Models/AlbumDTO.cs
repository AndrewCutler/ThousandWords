public class AlbumDTO
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<ImageDTO> Images { get; set; } = new();

    public AlbumDTO(Album sourceEntity)
    {
        this.Id = sourceEntity.Id;
        this.UserId = sourceEntity.UserId;
        this.Name = sourceEntity.Name;
        this.Images = sourceEntity.Images
            .Select(image => new ImageDTO(image))
            .ToList();
    }
}