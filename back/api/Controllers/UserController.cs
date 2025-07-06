using Microsoft.AspNetCore.Mvc;
using WannaTravel.API.Contracts;
using WannaTravel.Infrastructure.Entities;
using WannaTravel.Logic;

namespace WannaTravel.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserLogic userLogic;

    public UserController(IUserLogic userLogic)
    {
        this.userLogic = userLogic;
    }

    [HttpGet]
    public async Task<IEnumerable<User>> Get()
        => await userLogic.ReadAllUsers();

    [HttpPost]
    public async Task<IActionResult> CheckIfUserIsValid(CheckIfUserIsValidDto req)
    {
        var res = await userLogic.IsValid(req.Email, req.Password);

        if (!res.IsEmailFound)
            return BadRequest();

        if (!res.IsPasswordCorrect)
            return Unauthorized();

        return Ok();
    }
}
