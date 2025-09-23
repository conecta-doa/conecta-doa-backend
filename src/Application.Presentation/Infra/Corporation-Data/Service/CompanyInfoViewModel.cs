
using System.Text.Json.Serialization;
using Application.Presentation.Domain.Enums;

namespace Application.Presentation.Service
{
    public class CompanyInfoViewModel
    {
     [JsonPropertyName("cnpj")]
    public string Cnpj { get; set; }

    [JsonPropertyName("razao_social")]
    public string LegalName { get; set; }

    [JsonPropertyName("nome_fantasia")]
    public string TradeName{ get; set; }

    [JsonPropertyName("cep")]
    public string PostalCode{ get; set; }

    [JsonPropertyName("situacao_cadastral")]
    public EEstablishmentRegistrationStatus RegistrationStatus { get; set; } 

    [JsonPropertyName("data_inicio_atividade")]
    public string OpeningDate  { get; set; }
    }
}