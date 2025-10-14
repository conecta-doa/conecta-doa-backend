using System.Text.Json.Serialization;
using Application.Presentation.Domain.Enum;

namespace Application.Presentation.Domain.Models;

public class CompanyValidation
{
    
    [JsonPropertyName("cnpj")]
    public string Cnpj { get; init; }

    [JsonPropertyName("razao_social")]
    public string LegalName { get; init; }

    [JsonPropertyName("nome_fantasia")]
    public string TradeName { get; init; }

    [JsonPropertyName("cep")]
    public string PostalCode { get; init; }

    [JsonPropertyName("situacao_cadastral")]
    public Enum_corporation RegistrationStatus { get; init; }

    [JsonInclude] 
    [JsonPropertyName("status_mensagem")]
    public string Mensagem { get; init; } 
    
    [JsonPropertyName("data_inicio_atividade")]
    public DateTime? OpeningDate { get; set; }
}