public interface IAlbumService
{
    Task<List<Album>> GetUserAlbumsAsync(Guid userId);
    Task CreateAlbumAsync(string name, Guid userId);
    Task RenameAlbumAsync(Guid albumId, string name);
    Task DeleteAlbumAsync(Guid albumId);
}