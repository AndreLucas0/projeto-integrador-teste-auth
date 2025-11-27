using System.Text.Json.Serialization;

namespace api.Models;

public class Address
{
    public long Id { get; private set; }
    public required string Street { get; set; }
    public required string Number { get; set; }
    public required string City { get; set; }
    public required string FederativeUnit { get; set; }
    public long ClientId { get; set; }
    [JsonIgnore]
    public Client? Client { get; set; }
    public long DealershipId { get; set; }
    [JsonIgnore]
    public Dealership? Dealership { get; set; }
}