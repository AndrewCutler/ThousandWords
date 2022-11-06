public interface IAlbumService
{
    Task<List<Album>> GetUserAlbumsAsync(Guid userId);
    Task CreateAlbumAsync(string name, Guid userId);
    Task DeleteAlbumAsync(Guid albumId);
}