using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AppController : ControllerBase
{
    [HttpGet]
    public string Get() => "Hello world";

    [HttpGet("image")]
    public async Task<ActionResult> GetImageByIdAsync(Guid id)
    {
        return this.Ok("image.png");
    }
}