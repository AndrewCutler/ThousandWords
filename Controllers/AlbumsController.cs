using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AlbumController : ControllerBase
{
    private readonly IAlbumService _albumService;

    public AlbumController(IAlbumService albumService)
    {
        this._albumService = albumService;
    }

    [HttpGet]
    public async Task<ActionResult<List<AlbumDTO>?>> GetUserAlbumsAsync(Guid userId)
    {
        try
        {

            var albums = await this._albumService.GetUserAlbumsAsync(userId);

            var result = albums
                .Select(album => new AlbumDTO(album))
                .ToList();

            return this.Ok(result);
        }
        catch (Exception ex)
        {
            return this.BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> CreateAlbumAsync([FromBody] AlbumPostDTO request)
    {
        try
        {
            await this._albumService.CreateAlbumAsync(request.Name, request.UserId);

            return this.Ok();
        }
        catch (Exception ex)
        {
            return this.BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> RenameAlbumAsync(Guid albumId, string name)
    {
        try
        {
            await this._albumService.RenameAlbumAsync(albumId, name);

            return this.Ok();
        }
        catch (Exception ex)
        {
            return this.BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteAlbumAsync(Guid albumId)
    {
        try
        {
            await this._albumService.DeleteAlbumAsync(albumId);

            return this.Ok();
        }
        catch (Exception ex)
        {
            return this.BadRequest(ex.Message);
        }
    }
}