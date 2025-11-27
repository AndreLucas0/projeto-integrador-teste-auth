using System.Threading.Tasks;
using api.Data;
using api.Interfaces.Repositories;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class UserRepository : IUserRepository
{

    private readonly BackEndAPIContext _context;

    public UserRepository(BackEndAPIContext context)
    {
        _context = context;
    }

    public async Task Add(User user)
    {
        _context.User.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetByUsername(string username)
    {
        var user = await _context.User.FirstOrDefaultAsync(u => u.Username == username);
        return user;
    }
}