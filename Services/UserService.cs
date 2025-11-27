using api.Interfaces.Repositories;
using api.Interfaces.Services;
using api.Models;

namespace api.Services;

public class UserService : IUserService
{

    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
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