using System.Text.RegularExpressions;

namespace Conecta.Doa.Application.Presentation.Domain.Core.DomainObjects;

public class Validations
{
    public static void ValidateIfEqual(object obj1, object obj2, string message)
    {
        if (obj1.Equals(obj2))
            throw new DomainException(message);
    }

    public static void ValidateIfDifferent(object obj1, object obj2, string message)
    {
        if (!obj1.Equals(obj2))
            throw new DomainException(message);
    }

    public static void ValidateCharacters(string value, int maxLength, string message)
    {
        var length = value.Trim().Length;
        if (length > maxLength)
            throw new DomainException(message);
    }

    public static void ValidateCharacters(string value, int minLength, int maxLength, string message)
    {
        var length = value.Trim().Length;
        if (length < minLength || length > maxLength)
            throw new DomainException(message);
    }

    public static void ValidateExpression(string pattern, string value, string message)
    {
        var regex = new Regex(pattern);
        if (!regex.IsMatch(value))
            throw new DomainException(message);
    }

    public static void ValidateIfEmpty(string value, string message)
    {
        if (string.IsNullOrEmpty(value) || value.Trim().Length == 0)
            throw new DomainException(message);
    }

    public static void ValidateIfNull(object obj, string message)
    {
        if (obj == null)
            throw new DomainException(message);
    }

    public static void ValidateMinMax(double value, double min, double max, string message)
    {
        if (value < min || value > max)
            throw new DomainException(message);
    }

    public static void ValidateMinMax(float value, float min, float max, string message)
    {
        if (value < min || value > max)
            throw new DomainException(message);
    }

    public static void ValidateMinMax(int value, int min, int max, string message)
    {
        if (value < min || value > max)
            throw new DomainException(message);
    }

    public static void ValidateMinMax(long value, long min, long max, string message)
    {
        if (value < min || value > max)
            throw new DomainException(message);
    }

    public static void ValidateMinMax(decimal value, decimal min, decimal max, string message)
    {
        if (value < min || value > max)
            throw new DomainException(message);
    }

    public static void ValidateIfLessThan(long value, long min, string message)
    {
        if (value < min)
            throw new DomainException(message);
    }

    public static void ValidateIfLessThan(decimal value, decimal min, string message)
    {
        if (value < min)
            throw new DomainException(message);
    }

    public static void ValidateIfLessThan(double value, double min, string message)
    {
        if (value < min)
            throw new DomainException(message);
    }

    public static void ValidateIfLessThan(int value, int min, string message)
    {
        if (value < min)
            throw new DomainException(message);
    }

    public static void ValidateIfFalse(bool condition, string message)
    {
        if (!condition)
            throw new DomainException(message);
    }

    public static void ValidateIfTrue(bool condition, string message)
    {
        if (condition)
            throw new DomainException(message);
    }
}
