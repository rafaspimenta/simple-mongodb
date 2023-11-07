using Luppy.Models;
using Luppy.Services;
using Microsoft.AspNetCore.Mvc;

namespace Luppy.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserService _userService;

    public UsersController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IList<User>> GetUsersAsync() => await _userService.GetUsersAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<User> GetUserAsync(string id) => await _userService.GetUserAsync(id);

    [HttpPost]
    public async Task<IActionResult> CreateUserAsync(User newUser)
    {
        await _userService.CreaterAsync(newUser);
        return CreatedAtAction("GetUser", new { id = newUser.Id }, newUser);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> ReplaceUserAsync(string id, User newUser)
    {
        await _userService.ReplaceAsync(id, newUser);
        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> DeleteUserAsync(string id)
    {
        await _userService.DeleteAsync(id);
        return NoContent();
    }    
}
