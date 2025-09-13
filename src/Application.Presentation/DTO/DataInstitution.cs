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

        [JsonPropertyName("logradouro")]
        public string Logradouro { get; set; }

        [JsonPropertyName("numero")]
        public string Numero { get; set; }

        [JsonPropertyName("complemento")]
        public string Complemento { get; set; }

        [JsonPropertyName("bairro")]
        public string Bairro { get; set; }

        [JsonPropertyName("municipio")]
        public string Municipio { get; set; }

        [JsonPropertyName("uf")]
        public string Uf { get; set; }

        [JsonPropertyName("email")]
        public string EmailInstitucional { get; set; }

        [JsonPropertyName("descricao_situacao_cadastral")]
        public string SituacaoCadastral { get; set; }

        [JsonPropertyName("data_abertura")]
        public string DataAbertura { get; set; }
    }
}