using Fidar.Application.Users.Contracts;
using Fidar.Application.Users.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Fidar.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserApplicationServices _user;

    public UserController(UserApplicationServices user)
    {
        _user = user;
    }

    [HttpPost]
    public async Task<IActionResult> Add(UserDto user)
    {
        return Ok(await _user.Add(user));
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _user.Delete(id);
        return Ok();
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _user.GetAll());
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _user.GetById(id));
    }
    [HttpPut]
    public async Task<IActionResult> Update(int id, UserDto user)
    {
        await _user.Update(id, user);
        return Ok();
    }
}
