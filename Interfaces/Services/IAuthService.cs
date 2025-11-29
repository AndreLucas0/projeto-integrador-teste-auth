using api.DTOs.Auth;
using api.Models;

namespace api.Interfaces.Services;

public interface IAuthService
{
    
    Task<User?> Register(RegisterDTO dto);
    Task<AuthResponseDTO?> Login(LoginDTO dto);
}