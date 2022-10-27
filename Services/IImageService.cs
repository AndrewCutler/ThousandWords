public interface IImageService
{
    Task SaveImageAsync(string imageData, Guid userId);
}