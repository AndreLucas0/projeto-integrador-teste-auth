using api.Interfaces.Enums;

namespace api.DTOs.Auth;

public class LegalEntityRegisterDTO
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public required UserRoleEnum Role { get; set; }
    public string BusinessName { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;   
}