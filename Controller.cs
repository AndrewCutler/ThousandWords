using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AppController : ControllerBase
{
    private readonly IImageService _imageService;

    public AppController(IImageService imageService)
    {
        this._imageService = imageService;
    }

    [HttpGet]
    public string Get() => "Hello world";

    [HttpGet("image")]
    public async Task<ActionResult> GetImageByIdAsync(Guid id)
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
}