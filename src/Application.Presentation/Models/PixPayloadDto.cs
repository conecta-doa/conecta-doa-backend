using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using QRCoder;

namespace Conecta.Doa.Application.Presentation.Models;

public record PixPayloadDto
{
    [Required(ErrorMessage = "The PixKeyReciever field is required.")]
    public required string PixKeyReceiver { get; init; }

    [Required(ErrorMessage = "The Value field is required.")]
    public required double Value { get; init; }

    [Required(ErrorMessage = "The Name field is required.")]
    public required string Name { get; init; }

    [Required(ErrorMessage = "The City field is required.")]
    public required string City { get; init; }

    public string? Message { get; set; }

//Geração do QR Code em Base64
    public string GenerateQrCode()
    {
        var payload = GeneratePayload();

        using var qrGenerator = new QRCodeGenerator();
        using var qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
        using var qrCode = new PngByteQRCode(qrCodeData);

        var qrBytes = qrCode.GetGraphic(20);
        return Convert.ToBase64String(qrBytes);
    }
//Geração do payload conforme o padrão EMV para pagamentos via Pix
    public string GeneratePayload()
    {
        
        string gui = "br.gov.bcb.pix";
        string key = Normalize(PixKeyReceiver);
        string name = Normalize(Name);
        string city = Normalize(City);
        string amount = Value.ToString("F2", CultureInfo.InvariantCulture); // 1.00

        string msg = string.IsNullOrWhiteSpace(Message)
            ? "Doacao via Conecta Doa"
            : Normalize(Message!);

        
        var merchantAccount = $"00{gui.Length:D2}{gui}01{key.Length:D2}{key}";

        
        string additional = string.Empty;
        if (!string.IsNullOrWhiteSpace(msg))
        {
            var addInfo = $"05{msg.Length:D2}{msg}";
            additional = $"62{addInfo.Length:D2}{addInfo}";
        }

        var payload = new StringBuilder();
        payload.Append("000201"); 
        payload.Append($"26{merchantAccount.Length:D2}{merchantAccount}");
        payload.Append("52040000"); 
        payload.Append("5303986");  
        payload.Append($"54{amount.Length:D2}{amount}");
        payload.Append("5802BR");
        payload.Append($"59{name.Length:D2}{name}");
        payload.Append($"60{city.Length:D2}{city}");
        payload.Append(additional);
        payload.Append("6304"); 

        var crc = GenerateCRC16(payload.ToString());
        return payload + crc;
    }
//Remove acentos e caracteres especiais, deixando apenas ASCII.
    private static string Normalize(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return string.Empty;
        var normalized = input.Normalize(NormalizationForm.FormD);
        var sb = new StringBuilder();
        foreach (var c in normalized)
        {
            var cat = CharUnicodeInfo.GetUnicodeCategory(c);
            if (cat != UnicodeCategory.NonSpacingMark && c <= 127) 
                sb.Append(c);
        }
        return sb.ToString();
    }
//Cálculo do CRC16-CCITT (0xFFFF)
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
                resultado = (ushort)((resultado & 0x8000) != 0
                    ? (resultado << 1) ^ polinomio
                    : resultado << 1);
            }
        }
        return resultado.ToString("X4");
    }

    public record PixPayloadResponse
    {
        public required bool IsSuccess { get; init; }
        public string? CopyPaste { get; init; }
        public string? QrCode { get; init; }
        public string? Error { get; init; }
    }
}
