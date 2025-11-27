namespace api.Models;

public class LegalEntity : Client
{
    public required string BusinessName { get; set; }
    public required string CompanyName { get; set; }
    public required string Cnpj { get; set; }
}