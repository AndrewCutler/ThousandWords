using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AlbumController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetUserAlbumsAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<ActionResult> CreateAlbumAsync([FromBody] dynamic request) // TODO: dto for album name, user Id, image IDs (?)
    {
        throw new NotImplementedException();
    }
}