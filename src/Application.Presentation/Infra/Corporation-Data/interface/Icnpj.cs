using System.Threading.Tasks;
using Application.Presentation.Dto;

namespace Application.Presentation.Interfaces
{
    public interface ICorporation_information
    {
        
        Task<DataInstitution> GetAsync(string cnpj);
    }
}