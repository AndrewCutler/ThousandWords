using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AppController : ControllerBase
{
    [HttpGet]
    public string Get() => "Hello world";
}