using api.Models;

namespace api.Interfaces.Services;

public interface DealershipService
{
    Task<List<Dealership>> GetAll();
    Task<Dealership?> GetById(long id);
    Task<Dealership> Create(CreateLegalEntityDTO dto);
    Task<Dealership?> Update(long id, UpdateLegalEntityDTO dto);
    Task<bool> Delete(long id);
}