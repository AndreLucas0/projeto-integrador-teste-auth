using System.Threading.Tasks;
using api.Data;
using api.Interfaces.Repositories;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class LegalEntityRepository : ILegalEntityRepository
{

    private readonly BackEndAPIContext _context;

    public LegalEntityRepository(BackEndAPIContext context)
    {
        _context = context;
    }

    public async Task<LegalEntity> Create(LegalEntity legalEntity)
    {
        _context.LegalEntity.Add(legalEntity);
        await _context.SaveChangesAsync();
        return legalEntity;
    }

    public async Task<bool> Delete(long id)
    {
        var entity = await GetById(id);
        if (entity == null)
        {
            return false;
        }

        _context.LegalEntity.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<LegalEntity>> GetAll()
    {
        return await _context.LegalEntity
                             .Include(c => c.Phones)
                             .Include(c => c.Emails)
                             .Include(c => c.Addresses)
                             .ToListAsync();
    }

    public async Task<LegalEntity?> GetById(long id)
    {
        return await _context.LegalEntity
                             .Include(c => c.Phones)
                             .Include(c => c.Emails)
                             .Include(c => c.Addresses)
                             .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<LegalEntity> Update(LegalEntity legalEntity)
    {
        _context.LegalEntity.Update(legalEntity);
        await _context.SaveChangesAsync();
        return legalEntity;
    }

    public async Task<LegalEntity> Save(LegalEntity legalEntity)
    {
        await _context.SaveChangesAsync();
        return legalEntity;
    }
}