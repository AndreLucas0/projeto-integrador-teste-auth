using System.Threading.Tasks;
using api.Data;
using api.DTOs.Address;
using api.DTOs.Client;
using api.DTOs.LegalEntity;
using api.Interfaces.Repositories;
using api.Interfaces.Services;
using api.Models;
using api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace api.Services;

public class LegalEntityService : ILegalEntityService
{
    
    private readonly ILegalEntityRepository _repository;
    private readonly ViaCepService _viaCepService;

    public LegalEntityService (ILegalEntityRepository repository, ViaCepService viaCepService)
    {
        _repository = repository;
        _viaCepService = viaCepService;
    }
    
    public async Task<LegalEntity> Create(CreateLegalEntityDTO dto)
    {
        var legalEntity = new LegalEntity{
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            BusinessName = dto.BusinessName,
            CompanyName = dto.CompanyName,
            Cnpj = dto.Cnpj
        };

        return await _repository.Create(legalEntity);
    }

    public async Task<bool> Delete(long id)
    {
        return await _repository.Delete(id);
    }

    public async Task<List<LegalEntity>> GetAll()
    {
        return await _repository.GetAll();
    }

    public async Task<LegalEntity?> GetById(long id)
    {
        return await _repository.GetById(id);
    }

    public async Task<LegalEntity?> Update(long id, UpdateLegalEntityDTO dto)
    {
        var legalEntity = await _repository.GetById(id);
        if (legalEntity == null)
        {
            return null;
        }

        if (!string.IsNullOrWhiteSpace(dto.BusinessName))
        {
            legalEntity.BusinessName = dto.BusinessName;
        } if (!string.IsNullOrWhiteSpace(dto.CompanyName))
        {
            legalEntity.CompanyName = dto.CompanyName;
        }

        legalEntity.UpdatedAt = DateTime.UtcNow;

        return await _repository.Update(legalEntity);
    }

    public async Task<LegalEntity?> AddPhone(long id, CreatePhoneDTO dto)
    {
        var legalEntity = await GetById(id);
        if (legalEntity == null)
        {
            return null;
        }
        var phone = new Phone {
            Number = dto.Number,
            Client = legalEntity
        };

        legalEntity.AddPhone(phone);
        return await _repository.Save(legalEntity);
    }

    public async Task<List<Phone>> GetAllPhones(long id)
    {
        var legalEntity = await GetById(id);
        if (legalEntity == null)
        {
            return new List<Phone>();
        }
        return legalEntity.Phones;

    }

    public async Task<Phone?> GetPhoneById(long id, long phoneId)
    {
        var legalEntity = await GetById(id);
        if (legalEntity == null)
        {
            return null;
        }   
        var phone = legalEntity.GetPhoneById(phoneId);
        if (phone == null)
        {
            return null;
        }
        return phone;
    }

    public async Task<bool> RemovePhone(long id, long phoneId)
    {
        var legalEntity = await GetById(id);
        if (legalEntity == null)
        {
            return false;
        }
        legalEntity.RemovePhone(phoneId);
        await _repository.Save(legalEntity);
        return true;
    }

    public async Task<LegalEntity?> UpdatePhone(long id, long phoneId, UpdatePhoneDTO dto)
    {
        var legalEntity = await GetById(id);
        if (legalEntity == null)
        {
            return null;
        }
        var phone = legalEntity.GetPhoneById(phoneId);
        if (phone == null)
        {
            return null;
        }
        if (!string.IsNullOrWhiteSpace(dto.Number))
        {
            phone.Number = dto.Number;
        }

        legalEntity.UpdatedAt = DateTime.UtcNow;

        return await _repository.Save(legalEntity);
    }

    public async Task<LegalEntity?> AddEmail(long id, CreateEmailDTO dto)
    {
        var legalEntity = await GetById(id);
        if (legalEntity == null)
        {
            return null;
        }
        var email = new Email {
            EmailAddress = dto.EmailAddress,
            Client = legalEntity
        };

        legalEntity.AddEmail(email);
        return await _repository.Save(legalEntity);
    }

    public async Task<List<Email>> GetAllEmails(long id)
    {
        var legalEntity = await GetById(id);
        if (legalEntity == null)
        {
            return new List<Email>();
        }
        return legalEntity.Emails;
    }

    public async Task<Email?> GetEmailById(long id, long emailId)
    {
        var legalEntity = await GetById(id);
        if (legalEntity == null)
        {
            return null;
        }   
        var email = legalEntity.GetEmailById(emailId);
        if (email == null)
        {
            return null;
        }
        return email;
    }

    public async Task<bool> RemoveEmail(long id, long emailId)
    {
        var legalEntity = await GetById(id);
        if (legalEntity == null)
        {
            return false;
        }
        legalEntity.RemoveEmail(emailId);
        await _repository.Save(legalEntity);
        return true;
    }

    public async Task<LegalEntity?> UpdateEmail(long id, long emailId, UpdateEmailDTO dto)
    {
        var legalEntity = await GetById(id);
        if (legalEntity == null)
        {
            return null;
        }
        var email = legalEntity.GetEmailById(emailId);
        if (email == null)
        {
            return null;
        }
        if (!string.IsNullOrWhiteSpace(dto.EmailAddress))
        {
            email.EmailAddress = dto.EmailAddress;
        }

        legalEntity.UpdatedAt = DateTime.UtcNow;

        return await _repository.Save(legalEntity);
    }

    public async Task<LegalEntity?> AddAddress(long id, CreateAddressDTO dto)
    {
        var legalEntity = await GetById(id);
        if (legalEntity == null)
        {
            return null;
        }
        var viaCep = await _viaCepService.GetAddress(dto.Cep);

        var address = new Address
        {
            Cep = viaCep.Cep,
            Street = viaCep.Logradouro,
            District = viaCep.Bairro,
            City = viaCep.Localidade,
            State = viaCep.Uf,
            Number = dto.Number,
            Complement = dto.Complement
        };

        legalEntity.AddAddress(address);
        return await _repository.Save(legalEntity);
    }

    public async Task<List<Address>> GetAllAddresses(long id)
    {
        var legalEntity = await GetById(id);
        if (legalEntity == null)
        {
            return new List<Address>();
        }
        return legalEntity.Addresses;
    }

    public async Task<Address?> GetAddressById(long id, long addressId)
    {
        var legalEntity = await GetById(id);
        if (legalEntity == null)
        {
            return null;
        }   
        var address = legalEntity.GetAddressById(addressId);
        if (address == null)
        {
            return null;
        }
        return address;
    }

    public async Task<bool> RemoveAddress(long id, long addressId)
    {
        var legalEntity = await GetById(id);
        if (legalEntity == null)
        {
            return false;
        }
        legalEntity.RemoveAddress(addressId);
        await _repository.Save(legalEntity);
        return true;
    }

    // public async Task<LegalEntity?> UpdateAddress(long id, long addressId, UpdateAddressDTO dto)
    // {
    //     var legalEntity = await GetById(id);
    //     if (legalEntity == null)
    //     {
    //         return null;
    //     }
    //     var address = legalEntity.GetAddressById(addressId);
    //     if (address == null)
    //     {
    //         return null;
    //     }
    //     if (!string.IsNullOrWhiteSpace(dto.Street))
    //     {
    //         address.Street = dto.Street;
    //     } if (!string.IsNullOrWhiteSpace(dto.Number))
    //     {
    //         address.Number = dto.Number;
    //     } if (!string.IsNullOrWhiteSpace(dto.City))
    //     {
    //         address.City = dto.City;
    //     } if (!string.IsNullOrWhiteSpace(dto.FederativeUnit))
    //     {
    //         address.FederativeUnit = dto.FederativeUnit;
    //     }

    //     legalEntity.UpdatedAt = DateTime.UtcNow;

    //     return await _repository.Save(legalEntity);
    // }

}