// namespace api.Models;

// public class Dealership
// {
//     public long Id { get; private set; }
//     public required string Name { get; set; }
//     public required string Cnpj  { get; set; }
//     public required DateTime CreatedAt { get; set; }
//     public required DateTime UpdatedAt { get; set; }
//     public long AddressId { get; set; }
//     public Address? Address { get; set; }

//     public void AddAddress(Address address)
//     {
//         address.DealershipId = Id;
//         Address = address;
//     }

//     public void RemoveAddress()
//     {
//         Address = null;
//     }

//     public Address? GetAddress()
//     {
//         return Address;
//     }
// }