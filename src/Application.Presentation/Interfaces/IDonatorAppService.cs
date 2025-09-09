using Conecta.Doa.Application.Presentation.Models;

namespace Conecta.Doa.Application.Presentation.Interfaces;

public interface IDonatorAppService : IDisposable
{
    Task<PixPayloadRespone> CreatePixPayment(PixPayloadDto dto);
}