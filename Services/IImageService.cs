public interface IImageService
{
    Task<Image?> GetImageByIdAsync(Guid id);
    Task SaveImageAsync(string imageData, Guid userId);
}