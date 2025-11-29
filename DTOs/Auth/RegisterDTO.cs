using api.Interfaces.Enums;

namespace api.DTOs.Auth;

public class RegisterDTO
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required UserRoleEnum Role { get; set; }
}