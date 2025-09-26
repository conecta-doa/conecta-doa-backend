

using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using Application.Presentation.Service; 

using Application.Presentation.Interfaces;

namespace Application.Presentation.Services
{
    
    public class CompanyLookupService : ICompanyLookupService
    {
        private readonly HttpClient _httpClient;

        public CompanyLookupService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

       
      public async Task<CompanyInfoViewModel? >GetAsync(string cnpj)
{
    var relativeUrl = $"api/cnpj/v1/{cnpj}";

  
        HttpResponseMessage response = await _httpClient.GetAsync(relativeUrl);
        
        
        if (!response.IsSuccessStatusCode) return null;
        
        var jsonResponse = await response.Content.ReadAsStringAsync();
        var companyData = JsonSerializer.Deserialize<CompanyInfoViewModel>(jsonResponse);

        return companyData;
    }

}
        }
    