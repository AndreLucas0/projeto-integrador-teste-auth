using api.DTOs.Auth;
using api.Interfaces.Enums;
using api.Interfaces.Repositories;
using api.Interfaces.Services;
using api.Models;
using api.Repositories;
using Microsoft.AspNetCore.Identity;

namespace api.Services;

public class AuthService : IAuthService
{

    private readonly IUserRepository _repository;
    private readonly ILegalEntityRepository _legalEntityRepository;
    private readonly INaturalPersonRepository _naturalPersonRepository;
    private readonly ITokenService _tokenService;
    private readonly PasswordHasher<User> _passwordHasher = new();

    public AuthService(IUserRepository repository, ITokenService tokenService, ILegalEntityRepository legalEntityRepository, INaturalPersonRepository naturalPersonRepository)
    {
        _repository = repository;
        _tokenService = tokenService;
        _legalEntityRepository = legalEntityRepository;
        _naturalPersonRepository = naturalPersonRepository;
    }

    public async Task<AuthResponseDTO?> Login(LoginDTO dto)
    {
        var user = await _repository.GetByUsername(dto.Username);
        if (user == null)
        {
            return null;
        }

        var result = _passwordHasher.VerifyHashedPassword(user, user.Password, dto.Password);

        if (result == PasswordVerificationResult.Failed)
        {
            return null;
        }

        var token = _tokenService.GenerateToken(user);

        return new AuthResponseDTO
        {
            Username = user.Username,
            Role = user.Role.ToString(),
            Token = token
        };
    }

    public async Task<User?> RegisterLegalEntity(LegalEntityRegisterDTO dto)
    {
        var existing = await _repository.GetByUsername(dto.Username);
        if (existing != null)
        {
            return null;
        }

        var legalEntity = new LegalEntity
        {
            Username = dto.Username,
            Role = UserRoleEnum.LegalEntity,
            Password = "",
            BusinessName = dto.BusinessName,
            Cnpj = dto.Cnpj,
            CompanyName = dto.CompanyName,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        legalEntity.Password = _passwordHasher.HashPassword(legalEntity, dto.Password);

        await _legalEntityRepository.Create(legalEntity);

        return legalEntity;
    }

    public async Task<User?> RegisterNaturalPerson(NaturalPersonRegisterDTO dto)
    {
        var existing = await _repository.GetByUsername(dto.Username);
        if (existing != null)
        {
            return null;
        }

        var naturalPerson = new NaturalPerson
        {
            Username = dto.Username,
            Role = UserRoleEnum.NaturalPerson,
            Password = "",
            Name = dto.Name,
            Cpf = dto.Cpf,
            Birth = dto.Birth,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow

        };

        naturalPerson.Password = _passwordHasher.HashPassword(naturalPerson, dto.Password);

        await _naturalPersonRepository.Create(naturalPerson);

        return naturalPerson;
    }
}