using System.Text.Json.Serialization;

namespace Application.Presentation.Dto
{
    public class DataInstitution
    {
        [JsonPropertyName("cnpj")]
        public string Cnpj { get; set; }

        [JsonPropertyName("razao_social")]
        public string LegalName { get; set; }

        [JsonPropertyName("nome_fantasia")]
        public string TradeName { get; set; }

        [JsonPropertyName("cep")]
        public string PostalCode{ get; set; }

         [JsonPropertyName("situacao_cadastral ")]
        public string RegistrationStatus { get; set; }

        [JsonPropertyName("data_abertura")]
        public string OpeningDate { get; set; }
    }
}