using Microsoft.AspNetCore.Mvc;
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
}
