using Conecta.Doa.Application.Presentation.Interfaces;
using Conecta.Doa.Application.Presentation.Models;

namespace Conecta.Doa.Application.Presentation.Services;

public class DonatorAppService : IDonatorAppService
{
    public async Task<PixPayloadRespone> CreatePixPayment(PixPayloadDto dto)
    {
        var copyPaste = dto.GeneratePayload();

        var qrCode = dto.GenerateQrCode();

        return new PixPayloadRespone { IsSuccess = true, CopyPaste = copyPaste, QrCode = qrCode };
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
