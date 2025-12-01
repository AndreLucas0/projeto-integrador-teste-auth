using api.DTOs.Address;
using api.Interfaces.Services;

namespace api.Services;

public class ViaCepService : IViaCepService
{
    
    private readonly HttpClient _httpClient;

    public ViaCepService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ViaCepResponseDTO> GetAddress(string cep)
    {
        string url = $"https://viacep.com.br/ws/{cep}/json/";

        var response = await _httpClient.GetFromJsonAsync<ViaCepResponseDTO>(url);

        if (response == null || response.Error)
        {
            throw new Exception("Invalid CEP");
        }

        return response;
    }
}