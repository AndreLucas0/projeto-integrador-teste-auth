using api.DTOs.Address;

namespace api.Interfaces.Services;

public interface IViaCepService
{
    Task<ViaCepResponseDTO> GetAddress(string cep);
}