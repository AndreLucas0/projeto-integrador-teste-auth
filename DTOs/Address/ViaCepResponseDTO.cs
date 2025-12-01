namespace api.DTOs.Address;

public class ViaCepResponseDTO
{
    public required string Cep { get; set; }
    public required string Logradouro { get; set; }
    public required string Complemento { get; set; }
    public required string Bairro { get; set; }
    public required string Localidade { get; set; }
    public required string Uf { get; set; }
    public bool Error { get; set; }
}