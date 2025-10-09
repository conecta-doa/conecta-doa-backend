using System.Text.Json.Serialization;
using Application.Presentation.Infra.Enum;

namespace Application.Presentation.Service;

public class CompanyInfoViewModel
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

 
    public bool IsActive => RegistrationStatus == Enum_corporation.ACTIVE;

   
    public string StatusMessage
    {
        get
        {
            if (IsActive)
            {
                return "Empresa ativa e validada no cadastro da Receita Federal.";
            }

            
            string statusString = RegistrationStatus.ToString();

            
            string statusFormatado = char.ToUpper(statusString[0]) + statusString.Substring(1).ToLower();

            
            return $"A empresa não está ativa. Status atual: {statusFormatado}.";
        }
    }

    [JsonPropertyName("data_inicio_atividade")]
    public string OpeningDate { get; init; }
}
