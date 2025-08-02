using Microsoft.AspNetCore.Mvc;

namespace Notes.Controller;

[ApiController]
[Route("ping")]
public class PingController : ControllerBase
{
    [HttpGet]
    public IActionResult Ping()
    {
        return Ok("pong");
    }
}