using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Application.Presentation.Dto;

using Application.Presentation.Interfaces;

namespace Application.Presentation.Services
{
    // A classe agora implementa a interface correta
    public class CnpjService : IIBrasilAPI
    {
        private readonly HttpClient _httpClient;

        public CnpjService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // A assinatura deste método agora está correta, combinando com a interface
        public async Task<DataInstitution> GetAsync(string cnpj)
        {
            string apiUrl = $"https://brasilapi.com.br/api/cnpj/v1/{cnpj}";

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();

                var cnpjData = JsonConvert.DeserializeObject<DataInstitution>(jsonResponse);

                return cnpjData;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Erro ao consultar CNPJ: {e.Message}");
                return null;
            }
        }
    }
}