using api.DTOs.Auth;
using api.Interfaces.Services;
using api.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{

    private readonly ITokenService _service;

    public AuthController(ITokenService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult> login(LoginDTO dto)
    {
        var token = await _service.GenerateToken(dto);

        if (token == "")
        {
            return Unauthorized();
        }

        return Ok(token);
    }
    
}