using System.Text.RegularExpressions;

namespace Conecta.Doa.Application.Presentation.Domain.Core.DomainObjects;

public sealed record CNPJ
{
    public string Number { get; }

    private CNPJ(string number)
    {
        IsValid(number);
        
        Number = number;
    }

    /// <summary>
    /// Factory method that validates and creates a CNPJ.
    /// </summary>
    public static CNPJ Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("CNPJ cannot be empty.", nameof(value));

        string digitsOnly = OnlyDigits(value);

        if (!IsValid(digitsOnly))
            throw new ArgumentException("Invalid CNPJ.", nameof(value));

        return new CNPJ(digitsOnly);
    }

    /// <summary>
    /// Returns the CNPJ formatted with the standard mask.
    /// </summary>
    public string Formatted()
    {
        return Convert.ToUInt64(Number).ToString(@"00\.000\.000\/0000\-00");
    }

    private static string OnlyDigits(string value)
    {
        return Regex.Replace(value ?? "", "[^0-9]", "");
    }

    /// <summary>
    /// Validates the CNPJ using its check digits.
    /// </summary>
    public static bool IsValid(string cnpj)
    {
        if (cnpj.Length != 14)
            return false;

        if (new string(cnpj[0], cnpj.Length) == cnpj)
            return false;

        int[] multiplier1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplier2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        string tempCnpj = cnpj[..12];
        int sum = 0;

        for (int i = 0; i < 12; i++)
            sum += (tempCnpj[i] - '0') * multiplier1[i];

        int remainder = sum % 11;
        remainder = remainder < 2 ? 0 : 11 - remainder;
        string checkDigits = remainder.ToString();

        tempCnpj += checkDigits;
        sum = 0;

        for (int i = 0; i < 13; i++)
            sum += (tempCnpj[i] - '0') * multiplier2[i];

        remainder = sum % 11;
        remainder = remainder < 2 ? 0 : 11 - remainder;
        checkDigits += remainder.ToString();

        return cnpj.EndsWith(checkDigits);
    }

    public override string ToString() => Formatted();
}
