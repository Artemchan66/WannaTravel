using Microsoft.AspNetCore.Mvc;
using WannaTravel.Infrastructure.Entities;
using WannaTravel.Logic;
using WannaTravel.Logic.DTOs;
using WannaTravel.Logic.Interfaces;

namespace WannaTravel.API.Controllers;

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
    public async Task<IActionResult> Get()
        => Ok(await _userLogic.ReadAllUsers());

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserDto req)
    {
        var user = await _userLogic.Create(req.Name, req.Passwords);
        return Ok(new { user.Id, user.Name });
    }
}