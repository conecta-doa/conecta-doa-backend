using Conecta.Doa.Application.Presentation.Interfaces;
using Conecta.Doa.Application.Presentation.Models;
using System.Text.RegularExpressions;

namespace Conecta.Doa.Application.Presentation.Services;

public class DonatorAppService : IDonatorAppService
{
    public async Task<PixPayloadDto.PixPayloadResponse> CreatePixPayment(PixPayloadDto dto)
    {
        if (dto == null)
            return new PixPayloadDto.PixPayloadResponse { IsSuccess = false, Error = "DTO é nulo" };

        if (string.IsNullOrEmpty(dto.PixKeyReceiver))
            return new PixPayloadDto.PixPayloadResponse { IsSuccess = false, Error = "Chave Pix é obrigatória" };

        if (!PixKeyValidator.IsValid(dto.PixKeyReceiver))
            return new PixPayloadDto.PixPayloadResponse { IsSuccess = false, Error = "Chave Pix inválida" };

        if (dto.Value <= 0)
            return new PixPayloadDto.PixPayloadResponse { IsSuccess = false, Error = "Valor deve ser maior que zero" };

        try
        {
            var copyPaste = dto.GeneratePayload();
            var qrCode = dto.GenerateQrCode();

            return new PixPayloadDto.PixPayloadResponse
            {
                IsSuccess = true,
                CopyPaste = copyPaste,
                QrCode = qrCode
            };
        }
        catch (Exception ex)
        {
            return new PixPayloadDto.PixPayloadResponse { IsSuccess = false, Error = ex.Message };
        }
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}

/// Classe auxiliar para validar chaves Pix (CPF, CNPJ, telefone, e-mail, chave aleatória)
public static class PixKeyValidator
{
    public static bool IsValid(string key)
    {
        if (string.IsNullOrWhiteSpace(key))
            return false;

        key = key.Trim();

        // CPF (11 dígitos)
        if (Regex.IsMatch(key, @"^\d{11}$"))
            return true;

        // CNPJ (14 dígitos)
        if (Regex.IsMatch(key, @"^\d{14}$"))
            return true;

        // Telefone (+55DDXXXXXXXXX)
        if (Regex.IsMatch(key, @"^\+55\d{10,11}$"))
            return true;

        // E-mail
        if (Regex.IsMatch(key, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            return true;

        // Chave aleatória (UUID/GUID)
        if (Guid.TryParse(key, out _))
            return true;

        return false;
    }
}
