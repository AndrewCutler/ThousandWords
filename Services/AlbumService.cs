using Microsoft.EntityFrameworkCore;

public class AlbumService : IAlbumService
{
    private readonly AppContext _context;

    public AlbumService(AppContext context)
    {
        this._context = context;
    }

    public async Task<List<Album>> GetUserAlbumsAsync(Guid userId)
    {
        var albums = await this._context.Albums
            .Where(album => album.UserId == userId)
            .ToListAsync();

        return albums;
    }

    public async Task CreateAlbumAsync(string name, Guid userId)
    {
        this._context.Albums.Add(new Album
        {
            UserId = userId,
            Name = name,
        });

        await this._context.SaveChangesAsync();
    }

    public async Task RenameAlbumAsync(Guid albumId, string name)
    {
        var album = await this._context.Albums.FirstOrDefaultAsync(album => album.Id == albumId);

        if (album is null)
        {
            throw new Exception($"Cannot find album with ID {albumId}.");
        }

        album.Name = name;

        await this._context.SaveChangesAsync();
    }

    public async Task DeleteAlbumAsync(Guid albumId)
    {
        var album = await this._context.Albums.FirstOrDefaultAsync(album => album.Id == albumId);

        if (album is null)
        {
            throw new Exception($"Cannot find album with ID {albumId}.");
        }

        this._context.Albums.Remove(album);

        await this._context.SaveChangesAsync();
    }
}