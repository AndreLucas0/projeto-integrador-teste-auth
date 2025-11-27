using api.Models;

namespace api.Interfaces.Repositories;

public interface INaturalPersonRepository
{
    Task<List<NaturalPerson>> GetAll();
    Task<NaturalPerson?> GetById(long id);
    Task<NaturalPerson> Create(NaturalPerson naturalPerson);
    Task<NaturalPerson> Update(NaturalPerson naturalPerson);
    Task<bool> Delete(long id);
    Task<NaturalPerson> Save(NaturalPerson naturalPerson);
}