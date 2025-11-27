using System.Text.Json.Serialization;

namespace api.Models;

public class Phone
{
    public long Id { get; private set; }
    public required string Number { get; set; }
    public long ClientId { get; set; }
    [JsonIgnore]
    public Client? Client { get; set; }

}