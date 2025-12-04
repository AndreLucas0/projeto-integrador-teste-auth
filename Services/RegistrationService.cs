using api.DTOs.Auth;
using api.Interfaces.Repositories;
using api.Interfaces.Services;
using api.Models;
using api.Repositories;

namespace api.Services;

public class RegistrationService : IRegistrationService
{

    private readonly IUserService _userService;
    private readonly ILegalEntityRepository _legalEntityRepository;
    private readonly INaturalPersonRepository _naturalPersonRepository;

    public RegistrationService (IUserService userService, ILegalEntityRepository legalEntityRepository, NaturalPersonRepository naturalPersonRepository)
    {
        _userService = userService;
        _legalEntityRepository = legalEntityRepository;
        _naturalPersonRepository = naturalPersonRepository;
    }

    public Task RegisterLegalEntity(LegalEntityRegisterDTO dto)
    {
        
    }

    public Task RegisterNaturalPerson(NaturalPersonRegisterDTO dto)
    {
        throw new NotImplementedException();
    }
}