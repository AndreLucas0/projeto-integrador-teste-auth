namespace api.DTOs.Client;

public class UpdateAddressDTO
{
    public string Street { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string FederativeUnit { get; set; } = string.Empty;
}