using System.Text;

namespace Conecta.Doa.Application.Presentation.Dto;

public record PixPayloadDto
{
    public string PixKeyReciever { get; set; }
    public double Value { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public string Message { get; set; }

    public string GeneratePayload()
    {
        var value = Value.ToString("F2").Replace(',', '.');

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