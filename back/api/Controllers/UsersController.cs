using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WannaTravel.Logic.DTOs;
using WannaTravel.Logic.Interfaces;

namespace WannaTravel.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userLogic;

    public UsersController(IUserService userLogic)
    {
        _userLogic = userLogic;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _userLogic.ReadAll());
    
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetById(Guid userId)
    {
        var user = await _userLogic.ReadById(userId);
        if (user is null)
            return NotFound();
        return Ok(new { user.Id, user.Name });
    }

    [HttpGet("me")]
    public async Task<IActionResult> GetCurrentUser()
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var user = await _userLogic.ReadById(userId);
        if (user is null)
            return NotFound();
        return Ok(new { user.Id, user.Name });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserDto req)
    {
        var user = await _userLogic.Create(req.Name, req.Passwords);
        return Ok(new { user.Id, user.Name });
    }
}