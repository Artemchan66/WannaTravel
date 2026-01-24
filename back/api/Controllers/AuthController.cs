using Microsoft.AspNetCore.Mvc;
using WannaTravel.API.Services;
using WannaTravel.Logic.DTOs;

namespace WannaTravel.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ICookieAuthService _authService;

    public AuthController(ICookieAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto req)
    {
        var user = await _authService.Login(req.Username, req.Password);
        if (user == null) return Unauthorized(new { message = "Your credentials is ass" });
        return Ok(new { message = "All Gucci. Welcome" });
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await _authService.Logout();
        return Ok();
    }
}