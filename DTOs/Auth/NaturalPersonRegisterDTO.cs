using api.Interfaces.Enums;

namespace api.DTOs.Auth;

public class NaturalPersonRegisterDTO
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string Name { get; set; }
    public required string Cpf { get; set; }
    public required DateOnly Birth { get; set; }
}