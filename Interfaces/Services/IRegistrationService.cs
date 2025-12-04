using api.DTOs.Auth;

namespace api.Interfaces.Services;

public interface IRegistrationService
{
    Task RegisterNaturalPerson(NaturalPersonRegisterDTO dto);
    Task RegisterLegalEntity(LegalEntityRegisterDTO dto);
    
}