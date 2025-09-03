using Conecta.Doa.Application.Presentation.Dto;

namespace Conecta.Doa.Application.Presentation.Interfaces;

public interface IDonatorAppService : IDisposable
{
    Task<(string qrCode, string CopyPaste)> CreatePixPayment(PixPayloadDto dto);
}