using api.DTOs.Auth;
using api.Interfaces.Services;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{

    private readonly IAuthService _service;

    public AuthController(IAuthService service)
    {
        _service = service;
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login(LoginDTO dto)
    {
        var result = await _service.Login(dto);
        if (result == null)
        {
            return Unauthorized("Incorrect username or password.");
        }

        return Ok(result);
    }

    [HttpPost("registerNaturalPerson")]
    public async Task<ActionResult> RegisterNaturalPerson(NaturalPersonRegisterDTO dto)
    {
        var user = await _service.RegisterNaturalPerson(dto);
        if (user == null)
        {
            return BadRequest("Username already exists.");
        }

        return Ok("Natural person created successfully.");
    }

    [HttpPost("registerLegalEntity")]
    public async Task<ActionResult> RegisterLegalEntity(LegalEntityRegisterDTO dto)
    {
        var user = await _service.RegisterLegalEntity(dto);
        if (user == null)
        {
            return BadRequest("Username already exists.");
        }

        return Ok("Legal entity created successfully.");
    }
    
}