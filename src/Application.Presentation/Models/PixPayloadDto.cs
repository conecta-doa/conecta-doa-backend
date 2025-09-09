using System.ComponentModel.DataAnnotations;
using System.Text;
using QRCoder;

namespace Conecta.Doa.Application.Presentation.Models;

public record PixPayloadDto
{
    [Required(ErrorMessage = "The PixKeyReciever field is required.")]
    public required string PixKeyReciever { get; init; }

    [Required(ErrorMessage = "The Value field is required.")]
    public required double Value { get; init; }

    [Required(ErrorMessage = "The Name field is required.")]
    public required string Name { get; init; }

    [Required(ErrorMessage = "The City field is required.")]
    public required string City { get; init; }
    public string? Message { get; set; }

    public string GenerateQrCode()
    {
        var payload = GeneratePayload();

        using var qrGenerator = new QRCodeGenerator();
        using var qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);

        using var qrCode = new PngByteQRCode(qrCodeData);
        var qrBytes = qrCode.GetGraphic(20);

        return Convert.ToBase64String(qrBytes);
    }

    public string GeneratePayload()
    {
        var value = Value.ToString("F2").Replace(',', '.');

        if (Message is null)
            Message = "Doação via Conecta Doa";

        string payload = $"000201" +
                         $"26360014BR.GOV.BCB.PIX0114{PixKeyReciever}" +
                         $"52040000" +
                         $"5303986" +
                         $"54{value.Length:D2}{value}" +
                         $"5802BR" +
                         $"59{Name.Length:D2}{Name}" +
                         $"60{City.Length:D2}{City}" +
                         $"62{Message.Length + 4:D2}05{Message.Length:D2}{Message}" +
                         $"6304";

        var crc = GenerateCRC16(payload);

        return payload + crc;
    }

    private static string GenerateCRC16(string input)
    {
        ushort polinomio = 0x1021;
        ushort resultado = 0xFFFF;

        byte[] bytes = Encoding.ASCII.GetBytes(input);

        foreach (byte b in bytes)
        {
            resultado ^= (ushort)(b << 8);
            for (int i = 0; i < 8; i++)
            {
                if ((resultado & 0x8000) != 0)
                {
                    resultado = (ushort)((resultado << 1) ^ polinomio);
                }
                else
                {
                    resultado <<= 1;
                }
            }
        }

        return resultado.ToString("X4");
    }
}

public record PixPayloadRespone
{
    public required bool IsSuccess { get; init; }
    public string? CopyPaste { get; init; }
    public string? QrCode { get; init; }
}