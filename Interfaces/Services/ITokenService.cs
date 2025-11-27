using api.DTOs.Auth;
using api.Models;
using Microsoft.AspNetCore.Identity.Data;

namespace api.Interfaces.Services;

public interface ITokenService
{
    Task<string> GenerateToken(LoginDTO dto);
}