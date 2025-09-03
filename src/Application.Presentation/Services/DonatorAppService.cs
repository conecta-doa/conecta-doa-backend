using Conecta.Doa.Application.Presentation.Dto;
using Conecta.Doa.Application.Presentation.Interfaces;

namespace Conecta.Doa.Application.Presentation.Services;

public class DonatorAppService : IDonatorAppService
{
    public async Task<(string qrCode, string CopyPaste)> CreatePixPayment(PixPayloadDto dto)
    {
        
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
