using System.Text.Json.Serialization;

namespace Application.Presentation.Dto
{
    public class DataInstitution
    {
     [JsonPropertyName("cnpj")]
    public string Cnpj { get; set; }

    [JsonPropertyName("razao_social")]
    public string RazaoSocial { get; set; }

    [JsonPropertyName("nome_fantasia")]
    public string NomeFantasia { get; set; }

    [JsonPropertyName("cep")]
    public string Cep { get; set; }

    [JsonPropertyName("situacao_cadastral")]
    public string SituacaoCadastral { get; set; }

    [JsonPropertyName("data_abertura")]
    public string DataAbertura { get; set; }
    }
}