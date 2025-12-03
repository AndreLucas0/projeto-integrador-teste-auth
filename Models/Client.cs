using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

public abstract class Client : User
{
    public List<Email> Emails { get; set; } = new ();
    public List<Phone> Phones { get; set; } = new ();
    public List<Address> Addresses { get; set; } = new ();
    public required DateTime CreatedAt { get; set; }
    public required DateTime UpdatedAt { get; set; }

    public void AddPhone(Phone phone)
    {
        phone.ClientId = Id;
        Phones.Add(phone);
    }

    public void RemovePhone(long phoneId)
    {
        Phones.RemoveAll(p => p.Id == phoneId);
    }

    public Phone? GetPhoneById(long phoneId)
    {
        return Phones.FirstOrDefault(p => p.Id == phoneId);
    }

    public void AddEmail(Email email)
    {
        email.ClientId = Id;
        Emails.Add(email);
    }

    public void RemoveEmail(long emailId)
    {
        Emails.RemoveAll(e => e.Id == emailId);
    }

    public Email? GetEmailById(long emailId)
    {
        return Emails.FirstOrDefault(e => e.Id == emailId);
    }

    public void AddAddress(Address address)
    {
        address.ClientId = Id;
        Addresses.Add(address);
    }

    public void RemoveAddress(long addressId)
    {
        Addresses.RemoveAll(a => a.Id == addressId);
    }

    public Address? GetAddressById(long addressId)
    {
        return Addresses.FirstOrDefault(a => a.Id == addressId);
    }
}