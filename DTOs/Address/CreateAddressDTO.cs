namespace api.DTOs.Address;

public class CreateAddressDTO
{
    public required string Cep { get; set; }
    public required string Number { get; set; }
    public required string Complement { get; set; }
}