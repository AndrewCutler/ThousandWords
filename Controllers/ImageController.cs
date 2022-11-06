using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ImageController : ControllerBase
{
    private readonly IImageService _imageService;

    public ImageController(IImageService imageService)
    {
        this._imageService = imageService;
    }

    [HttpGet]
    public async Task<ActionResult<GetImageDTO>> GetImageByIdAsync(Guid id)
    {
        try
        {
            var image = await this._imageService.GetImageByIdAsync(id);

            if (image is not null)
            {
                return this.Ok(new GetImageDTO(image));
            }

            return this.NotFound();
        }
        catch (Exception ex)
        {
            return this.BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> SaveImageAsync([FromBody] ImagePostDTO request)
    {
        try
        {
            await this._imageService.SaveImageAsync(request.ImageData, request.UserId);

            return this.Ok();
        }
        catch (Exception ex)
        {
            return this.BadRequest(ex.Message);
        }
    }

    [HttpPut("active")]
    public async Task<ActionResult> SetImageActivityAsync([FromBody] PutImageActiveDTO request)
    {
        try
        {
            await this._imageService.SetImageActiveAsync(request.ImageId, request.Active);

            return this.Ok();
        }
        catch (Exception ex)
        {
            return this.BadRequest(ex.Message);
        }
    }

    [HttpPost("link")]
    public async Task<ActionResult<string>> GetOrCreateLinkAsync(Guid imageId)
    {
        try
        {
            var url = await this._imageService.GetOrCreateLinkAsync(imageId);

            return this.Ok(url);
        }
        catch (Exception ex)
        {
            return this.BadRequest(ex.Message);
        }
    }

    [HttpGet("link")]
    public async Task<ActionResult> GetImageByLinkAsync(Guid linkId)
    {
        try
        {
            var image = await this._imageService.GetImageFromLinkAsync(linkId);

            return this.Ok(image);
        }
        catch (Exception ex)
        {
            return this.BadRequest(ex.Message);
        }
    }
}