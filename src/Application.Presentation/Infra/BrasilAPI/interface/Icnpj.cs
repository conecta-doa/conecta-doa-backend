using System.Threading.Tasks;
using Application.Presentation.Dto;

namespace Application.Presentation.Interfaces
{
    public interface IIBrasilAPI
    {
        // O método deve ser chamado 'GetAsync' e retornar a classe DTO correta
        Task<DataInstitution> GetAsync(string cnpj);
    }
}