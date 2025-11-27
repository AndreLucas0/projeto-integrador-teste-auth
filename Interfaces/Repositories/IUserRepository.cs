using api.Models;

namespace api.Interfaces.Repositories;

public interface IUserRepository
{
    Task Add(User user);
    Task<User?> GetByUsername(string username);
}