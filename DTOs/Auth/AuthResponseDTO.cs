using api.Interfaces.Enums;

namespace api.DTOs.Auth;

public class AuthResponseDTO
{
    public string Username { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
}