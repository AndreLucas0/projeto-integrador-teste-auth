using api.DTOs.Auth;
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

    public AuthService(IUserRepository repository, ITokenService tokenService, ILegalEntityRepository legalEntityRepository, NaturalPersonRepository naturalPersonRepository)
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

    public async Task<User?> Register(RegisterDTO dto)
    {
        var existing = await _repository.GetByUsername(dto.Username);
        if (existing != null)
        {
            return null;
        }

        var user = new User
        {
            Username = dto.Username,
            Role = dto.Role,
            Password = ""
        };

        user.Password = _passwordHasher.HashPassword(user, dto.Password);

        await _repository.Add(user);

        return user;
    }
}