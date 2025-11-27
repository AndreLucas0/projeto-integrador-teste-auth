using api.Models;

namespace api.Interfaces.Repositories;

public interface ILegalEntityRepository
{
    Task<List<LegalEntity>> GetAll();
    Task<LegalEntity?> GetById(long id);
    Task<LegalEntity> Create(LegalEntity legalEntity);
    Task<LegalEntity> Update(LegalEntity legalEntity);
    Task<bool> Delete(long id);
    Task<LegalEntity> Save(LegalEntity legalEntity);
}