using api.DTOs.Client;
using api.DTOs.NaturalPerson;
using api.Interfaces.Enums;
using api.Interfaces.Repositories;
using api.Interfaces.Services;
using api.Models;

namespace api.Services;

public class NaturalPersonService : INaturalPersonService
{

    private readonly INaturalPersonRepository _repository;

    public NaturalPersonService(INaturalPersonRepository repository)
    {
        _repository = repository;
    }

    public async Task<NaturalPerson> Create(CreateNaturalPersonDTO dto)
    {
        var naturalPerson = new NaturalPerson
        {
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            Name = dto.Name,
            Cpf = dto.Cpf,
            Birth = dto.Birth,
            Username = "aaaaa",
            Password = "aaaaa",
            Role = UserRoleEnum.NaturalPerson
        };

        return await _repository.Create(naturalPerson);
    }

    public async Task<bool> Delete(long id)
    {
        return await _repository.Delete(id);
    }

    public async Task<List<NaturalPerson>> GetAll()
    {
        return await _repository.GetAll();
    }

    public async Task<NaturalPerson?> GetById(long id)
    {
        return await _repository.GetById(id);
    }

    public async Task<NaturalPerson?> Update(long id, UpdateNaturalPersonDTO dto)
    {
        var naturalPerson = await _repository.GetById(id);
        if (naturalPerson == null)
        {
            return null;
        }

        if (!string.IsNullOrWhiteSpace(dto.Name))
        {
            naturalPerson.Name = dto.Name;
        }

        naturalPerson.UpdatedAt = DateTime.UtcNow;

        return await _repository.Update(naturalPerson);
    }

    public async Task<NaturalPerson?> AddPhone(long id, CreatePhoneDTO dto)
    {
        var naturalPerson = await GetById(id);
        if (naturalPerson == null)
        {
            return null;
        }
        var phone = new Phone {
            Number = dto.Number,
            Client = naturalPerson
        };

        naturalPerson.AddPhone(phone);
        return await _repository.Save(naturalPerson);
    }

    public async Task<List<Phone>> GetAllPhones(long id)
    {
        var naturalPerson = await GetById(id);
        if (naturalPerson == null)
        {
            return new List<Phone>();
        }
        return naturalPerson.Phones;

    }

    public async Task<Phone?> GetPhoneById(long id, long phoneId)
    {
        var naturalPerson = await GetById(id);
        if (naturalPerson == null)
        {
            return null;
        }   
        var phone = naturalPerson.GetPhoneById(phoneId);
        if (phone == null)
        {
            return null;
        }
        return phone;
    }

    public async Task<bool> RemovePhone(long id, long phoneId)
    {
        var naturalPerson = await GetById(id);
        if (naturalPerson == null)
        {
            return false;
        }
        naturalPerson.RemovePhone(phoneId);
        await _repository.Save(naturalPerson);
        return true;
    }

    public async Task<NaturalPerson?> UpdatePhone(long id, long phoneId, UpdatePhoneDTO dto)
    {
        var naturalPerson = await GetById(id);
        if (naturalPerson == null)
        {
            return null;
        }
        var phone = naturalPerson.GetPhoneById(phoneId);
        if (phone == null)
        {
            return null;
        }
        if (!string.IsNullOrWhiteSpace(dto.Number))
        {
            phone.Number = dto.Number;
        }

        naturalPerson.UpdatedAt = DateTime.UtcNow;

        return await _repository.Save(naturalPerson);
    }

    public async Task<NaturalPerson?> AddEmail(long id, CreateEmailDTO dto)
    {
        var naturalPerson = await GetById(id);
        if (naturalPerson == null)
        {
            return null;
        }
        var email = new Email {
            EmailAddress = dto.EmailAddress,
            Client = naturalPerson
        };

        naturalPerson.AddEmail(email);
        return await _repository.Save(naturalPerson);
    }

    public async Task<List<Email>> GetAllEmails(long id)
    {
        var naturalPerson = await GetById(id);
        if (naturalPerson == null)
        {
            return new List<Email>();
        }
        return naturalPerson.Emails;
    }

    public async Task<Email?> GetEmailById(long id, long emailId)
    {
        var naturalPerson = await GetById(id);
        if (naturalPerson == null)
        {
            return null;
        }   
        var email = naturalPerson.GetEmailById(emailId);
        if (email == null)
        {
            return null;
        }
        return email;
    }

    public async Task<bool> RemoveEmail(long id, long emailId)
    {
        var naturalPerson = await GetById(id);
        if (naturalPerson == null)
        {
            return false;
        }
        naturalPerson.RemoveEmail(emailId);
        await _repository.Save(naturalPerson);
        return true;
    }

    public async Task<NaturalPerson?> UpdateEmail(long id, long emailId, UpdateEmailDTO dto)
    {
        var naturalPerson = await GetById(id);
        if (naturalPerson == null)
        {
            return null;
        }
        var email = naturalPerson.GetEmailById(emailId);
        if (email == null)
        {
            return null;
        }
        if (!string.IsNullOrWhiteSpace(dto.EmailAddress))
        {
            email.EmailAddress = dto.EmailAddress;
        }

        naturalPerson.UpdatedAt = DateTime.UtcNow;

        return await _repository.Save(naturalPerson);
    }

    // public async Task<NaturalPerson?> AddAddress(long id, CreateAddressDTO dto)
    // {
    //     var naturalPerson = await GetById(id);
    //     if (naturalPerson == null)
    //     {
    //         return null;
    //     }
    //     var address = new Address {
    //         Street = dto.Street,
    //         Number = dto.Number,
    //         City = dto.City,
    //         FederativeUnit = dto.FederativeUnit,
    //         Client = naturalPerson
    //     };

    //     naturalPerson.AddAddress(address);
    //     return await _repository.Save(naturalPerson);
    // }

    // public async Task<List<Address>> GetAllAddresses(long id)
    // {
    //     var naturalPerson = await GetById(id);
    //     if (naturalPerson == null)
    //     {
    //         return new List<Address>();
    //     }
    //     return naturalPerson.Addresses;
    // }

    // public async Task<Address?> GetAddressById(long id, long addressId)
    // {
    //     var naturalPerson = await GetById(id);
    //     if (naturalPerson == null)
    //     {
    //         return null;
    //     }   
    //     var address = naturalPerson.GetAddressById(addressId);
    //     if (address == null)
    //     {
    //         return null;
    //     }
    //     return address;
    // }

    // public async Task<bool> RemoveAddress(long id, long addressId)
    // {
    //     var naturalPerson = await GetById(id);
    //     if (naturalPerson == null)
    //     {
    //         return false;
    //     }
    //     naturalPerson.RemoveAddress(addressId);
    //     await _repository.Save(naturalPerson);
    //     return true;
    // }

    // public async Task<NaturalPerson?> UpdateAddress(long id, long addressId, UpdateAddressDTO dto)
    // {
    //     var naturalPerson = await GetById(id);
    //     if (naturalPerson == null)
    //     {
    //         return null;
    //     }
    //     var address = naturalPerson.GetAddressById(addressId);
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

    //     naturalPerson.UpdatedAt = DateTime.UtcNow;

    //     return await _repository.Save(naturalPerson);
    // }
}