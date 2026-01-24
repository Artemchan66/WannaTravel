using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WannaTravel.Logic.DTOs;
using WannaTravel.Logic.Interfaces;

namespace WannaTravel.API.Controllers;

[Authorize]
[ApiController]
[Route("api/user/countries")]
public class UserCountriesController : ControllerBase
{
    private readonly IUserCountryService _service;

    public UserCountriesController(IUserCountryService service)
    {
        _service = service;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> Get(Guid userId)
    {
        var data = await _service.GetUserMap(userId);
        return Ok(data);
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var data = await _service.GetUserMap(userId);
        return Ok(data);
    }

    [HttpPatch]
    public async Task<IActionResult> Update(UpdateCountryDto req)
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        await _service.UpdateCountry(userId, req.Country, req.Status);
        return Ok();
    }
}