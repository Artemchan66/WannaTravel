using Microsoft.AspNetCore.Mvc;

namespace WannaTravel.API.Controllers;

[ApiController]
[Route("[controller]")]
public class MapController : ControllerBase
{
    [HttpGet("world")]
    public IActionResult GetWorldMap()
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "world.svg");
        var svg = System.IO.File.ReadAllText(path);
        return Content(svg, "image/svg+xml");
    }
}
