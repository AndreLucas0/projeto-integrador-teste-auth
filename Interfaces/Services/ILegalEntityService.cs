using api.DTOs.Address;
using api.DTOs.Client;
using api.DTOs.LegalEntity;
using api.Models;

namespace api.Interfaces.Services;

public interface ILegalEntityService
{
    Task<List<LegalEntity>> GetAll();
    Task<LegalEntity?> GetById(long id);
    Task<LegalEntity> Create(CreateLegalEntityDTO dto);
    Task<LegalEntity?> Update(long id, UpdateLegalEntityDTO dto);
    Task<bool> Delete(long id);
    Task<LegalEntity?> AddPhone(long id, CreatePhoneDTO dto);
    Task<LegalEntity?> AddEmail(long id, CreateEmailDTO dto);
    Task<LegalEntity?> AddAddress(long id, CreateAddressDTO dto);
    Task<List<Phone>> GetAllPhones(long id);
    Task<List<Email>> GetAllEmails(long id);
    Task<List<Address>> GetAllAddresses(long id);
    Task<Phone?> GetPhoneById(long id, long phoneId);
    Task<Email?> GetEmailById(long id, long emailId);
    Task<Address?> GetAddressById(long id, long addressId);
    Task<bool> RemovePhone(long id, long phoneId);
    Task<bool> RemoveEmail(long id, long emailId);
    Task<bool> RemoveAddress(long id, long phoneId);
    Task<LegalEntity?> UpdatePhone(long id, long phoneId, UpdatePhoneDTO dto);
    Task<LegalEntity?> UpdateEmail(long id, long emailId, UpdateEmailDTO dto);
    // Task<LegalEntity?> UpdateAddress(long id, long addressId, UpdateAddressDTO dto);
}