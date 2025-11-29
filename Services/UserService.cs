using api.DTOs.Auth;
using api.Interfaces.Repositories;
using api.Interfaces.Services;
using api.Models;
using Microsoft.AspNetCore.Identity;

namespace api.Services;

public class UserService : IUserService
{

    private readonly IUserRepository _repository;
    private readonly ITokenService _tokenService;
    private readonly PasswordHasher<User> _passwordHasher = new();

    public UserService(IUserRepository repository, ITokenService tokenService)
    {
        _repository = repository;
        _tokenService = tokenService;
    }

    public async Task Add(User user)
    {
        await _repository.Add(user);
    }

    public async Task<User?> GetByUsername(string username)
    {
        return await _repository.GetByUsername(username);
    }

}