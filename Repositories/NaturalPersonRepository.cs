using api.Data;
using api.Interfaces.Repositories;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class NaturalPersonRepository : INaturalPersonRepository
{

    private readonly BackEndAPIContext _context;

    public NaturalPersonRepository(BackEndAPIContext context)
    {
        _context = context;
    }

    public async Task<NaturalPerson> Create(NaturalPerson naturalPerson)
    {
        _context.NaturalPerson.Add(naturalPerson);
        await _context.SaveChangesAsync();
        return naturalPerson;
    }

    public async Task<bool> Delete(long id)
    {
        var naturalPerson = await GetById(id);
        if (naturalPerson == null)
        {
            return false;
        }

        _context.NaturalPerson.Remove(naturalPerson);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<NaturalPerson>> GetAll()
    {
        return await _context.NaturalPerson
                             .Include(c => c.Phones)
                             .Include(c => c.Emails)
                             .Include(c => c.Addresses)
                             .ToListAsync();
    }

    public async Task<NaturalPerson?> GetById(long id)
    {
        return await _context.NaturalPerson
                             .Include(c => c.Phones)
                             .Include(c => c.Emails)
                             .Include(c => c.Addresses)
                             .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<NaturalPerson> Update(NaturalPerson naturalPerson)
    {
        _context.NaturalPerson.Update(naturalPerson);
        await _context.SaveChangesAsync();
        return naturalPerson;
    }

    public async Task<NaturalPerson> Save(NaturalPerson naturalPerson)
    {
        await _context.SaveChangesAsync();
        return naturalPerson;
    }
}