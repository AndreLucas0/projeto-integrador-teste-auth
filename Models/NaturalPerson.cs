namespace api.Models;

public class NaturalPerson : Client
{
    public required string Name { get; set; }
    public required string Cpf { get; set; }
    public required DateOnly Birth { get; set; }
}