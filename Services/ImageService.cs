public class ImageService : IImageService
{

    private readonly AppContext _context;

    public ImageService(AppContext context)
    {
        this._context = context;
    }

    public async Task SaveImageAsync(string imageData, Guid userId)
    {
        this._context.Add(new Image
        {
            ImageData = imageData,
            UserId = userId,
            UploadDate = DateTime.UtcNow,
        });

        await this._context.SaveChangesAsync();
    }
}