using Microsoft.EntityFrameworkCore;

public class ImageService : IImageService
{

    private readonly AppContext _context;

    public ImageService(AppContext context)
    {
        this._context = context;
    }

    public async Task<Image?> GetImageByIdAsync(Guid id)
    {
        var image = await this._context.Images
            .Include(image => image.Link)
            .FirstOrDefaultAsync(image => image.Id == id);

        return image;
    }

    public async Task SaveImageAsync(string imageData, Guid userId)
    {
        this._context.Images.Add(new Image
        {
            ImageData = imageData,
            UserId = userId,
            Created = DateTime.UtcNow,
        });

        await this._context.SaveChangesAsync();
    }

    public async Task SetImageActiveAsync(Guid id, bool active)
    {
        var image = await this._context.Images.FirstOrDefaultAsync(image => image.Id == id);

        if (image is null)
        {
            throw new Exception($"Cannot find image with Id {id}.");
        }

        image.Active = active;

        await this._context.SaveChangesAsync();
    }

    public async Task<string> GetOrCreateLinkAsync(Guid imageId)
    {
        // TODO: replace with real domain
        var urlBase = "https://test.com/image?id=";
        var image = await this._context.Images
            .Include(image => image.Link)
            .FirstOrDefaultAsync(image => image.Id == imageId);

        if (image is null)
        {
            throw new Exception($"Cannot find image with Id {imageId}.");
        }

        if (image.Link is not null)
        {
            return $"{urlBase}{image.Link.Id.ToString()}";
        }

        var link = new Link
        {
            Created = DateTime.UtcNow,
        };

        image.Link = link;

        await this._context.SaveChangesAsync();

        return $"{urlBase}{link.Id.ToString()}";
    }

    public async Task<string> GetImageFromLinkAsync(Guid linkId)
    {
        var image = await this._context.Images
            .Include(image => image.Link)
            .FirstOrDefaultAsync(image => image.Link.Id == linkId);

        if (image is null)
        {
            throw new Exception($"Cannot find image with Link Id {linkId}.");
        }

        return image?.ImageData!;
    }
}