using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Application.Presentation.Dto;

using Application.Presentation.Interfaces;

namespace Application.Presentation.Services
{
    
    public class CnpjService : ICorporation_information
    {
        private readonly HttpClient _httpClient;

        public CnpjService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

       
      public async Task<DataInstitution> GetAsync(string cnpj)
{
    string relativeUrl = $"api/cnpj/v1/{cnpj}";

  
        HttpResponseMessage response = await _httpClient.GetAsync(relativeUrl);
        
        
        response.EnsureSuccessStatusCode(); 
        
        string jsonResponse = await response.Content.ReadAsStringAsync();
        var cnpjData = JsonConvert.DeserializeObject<DataInstitution>(jsonResponse);

        return cnpjData;
    }

}
        }
    