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
        return this.Ok("image.png");
    }

    [HttpPost]
    public async Task<ActionResult> SaveImageAsync([FromBody] ImagePostDTO request)
    {
        return this.Ok();
    }
}