using api.DTOs.Client;
using api.DTOs.NaturalPerson;
using api.Models;

namespace api.Interfaces.Services;

public interface INaturalPersonService
{
    Task<List<NaturalPerson>> GetAll();
    Task<NaturalPerson?> GetById(long id);
    Task<NaturalPerson> Create(CreateNaturalPersonDTO dto);
    Task<NaturalPerson?> Update(long id, UpdateNaturalPersonDTO dto);
    Task<bool> Delete(long id);
    Task<NaturalPerson?> AddPhone(long id, CreatePhoneDTO dto);
    Task<NaturalPerson?> AddEmail(long id, CreateEmailDTO dto);
    // Task<NaturalPerson?> AddAddress(long id, CreateAddressDTO dto);
    Task<List<Phone>> GetAllPhones(long id);
    Task<List<Email>> GetAllEmails(long id);
    // Task<List<Address>> GetAllAddresses(long id);
    Task<Phone?> GetPhoneById(long id, long phoneId);
    Task<Email?> GetEmailById(long id, long emailId);
    // Task<Address?> GetAddressById(long id, long addressId);
    Task<bool> RemovePhone(long id, long phoneId);
    Task<bool> RemoveEmail(long id, long emailId);
    // Task<bool> RemoveAddress(long id, long phoneId);
    Task<NaturalPerson?> UpdatePhone(long id, long phoneId, UpdatePhoneDTO dto);
    Task<NaturalPerson?> UpdateEmail(long id, long emailId, UpdateEmailDTO dto);
    // Task<NaturalPerson?> UpdateAddress(long id, long addressId, UpdateAddressDTO dto);
}