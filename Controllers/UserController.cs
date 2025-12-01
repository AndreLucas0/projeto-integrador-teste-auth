using System.Security.Claims;
using System.Threading.Tasks;
using api.Interfaces.Services;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
public class UserController : ControllerBase
{

    private readonly IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult> Create(User user)
    {
        await _service.Add(user);
        return Ok("User inserted successfully!");
    }

    [HttpGet]
    public async Task<IActionResult> GetUser()
    {
        var username = User.Identity?.Name;

        if (username == null)
        {
            return Unauthorized("No username claim found");
        }

        var user = await _service.GetByUsername(username);
        return Ok(user);
    }
    
}