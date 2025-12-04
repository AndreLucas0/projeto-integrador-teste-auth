using api.DTOs.Auth;
using api.Models;

namespace api.Interfaces.Services;

public interface IAuthService
{
    
    Task<User?> RegisterLegalEntity(LegalEntityRegisterDTO dto);
    Task<User?> RegisterNaturalPerson(NaturalPersonRegisterDTO dto);
    Task<AuthResponseDTO?> Login(LoginDTO dto);
}