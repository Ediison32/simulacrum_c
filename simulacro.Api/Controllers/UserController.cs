using Microsoft.AspNetCore.Mvc;
using simulacro.Application.Dto;
using simulacro.Application.Interfaces.Services;

namespace simulacro.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUsersService _usersService;

    public UserController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<IEnumerable<UsersDto>>> GetAllUser()
    {
        var result = await _usersService.GetAllUserAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UsersDto>> GetIdUser(int id)
    {
        var result = await _usersService.GetIdUserAsync(id);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteUser(int id)
    {
        var resul = await _usersService.DeleteUserAsync(id);
        return Ok(resul);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<UsersDto>> Create(UserCreateDto usersDto)
    {
        var resut = await _usersService.AddUserAsync(usersDto);
        return Ok(resut);
    }

}