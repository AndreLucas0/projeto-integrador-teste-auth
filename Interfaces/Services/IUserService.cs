using api.Models;

namespace api.Interfaces.Services;

public interface IUserService
{
    Task Add(User user);
    Task<User?> GetByUsername(string username);
}