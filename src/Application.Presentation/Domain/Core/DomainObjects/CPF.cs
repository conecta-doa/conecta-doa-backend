using System.Text.RegularExpressions;

namespace Conecta.Doa.Application.Presentation.Domain.Core.DomainObjects;

public sealed record CPF
{
    public string Number { get; }

    private CPF(string number)
    {
        IsValid(number);

        Number = number;
    }

    /// <summary>
    /// Factory method that validates and creates a CPF.
    /// </summary>
    public static CPF Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return null;

        string digitsOnly = OnlyDigits(value);

        if (!IsValid(digitsOnly))
            return null;

        return new CPF(digitsOnly);
    }

    /// <summary>
    /// Returns the CPF formatted with the standard mask.
    /// </summary>
    public string Formatted()
    {
        return Convert.ToUInt64(Number).ToString(@"000\.000\.000\-00");
    }

    private static string OnlyDigits(string value)
    {
        return Regex.Replace(value ?? "", "[^0-9]", "");
    }

    /// <summary>
    /// Validates a CPF using its check digits.
    /// </summary>
    public static bool IsValid(string cpf)
    {
        if (cpf.Length != 11)
            return false;

        if (new string(cpf[0], cpf.Length) == cpf)
            return false;

        int[] multiplier1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplier2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        string tempCpf = cpf[..9];
        int sum = 0;

        for (int i = 0; i < 9; i++)
            sum += (tempCpf[i] - '0') * multiplier1[i];

        int remainder = sum % 11;
        remainder = remainder < 2 ? 0 : 11 - remainder;
        string checkDigits = remainder.ToString();

        tempCpf += checkDigits;
        sum = 0;

        for (int i = 0; i < 10; i++)
            sum += (tempCpf[i] - '0') * multiplier2[i];

        remainder = sum % 11;
        remainder = remainder < 2 ? 0 : 11 - remainder;
        checkDigits += remainder.ToString();

        return cpf.EndsWith(checkDigits);
    }

    public override string ToString() => Formatted();
}
