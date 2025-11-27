using api.DTOs.Client;

namespace api.DTOs.LegalEntity;

public class ResponseLegalEntityDTO{

    public long Id { get; set; }
    public List<ResponsePhoneDTO> Phones { get; set; } = new ();
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

}