namespace Conecta.Doa.Application.Presentation.Domain.Core.DomainObjects;

public enum DonationType
{
    Clothes,
    Food,
    Financial
}

public sealed record Donation
{
    public DonationType Type { get; }
    public string Description { get; }
    public int? Quantity { get; }
    public decimal? Amount { get; }

    private Donation(DonationType type, string description, int? quantity, decimal? amount)
    {
        Type = type;
        Description = description;
        Quantity = quantity;
        Amount = amount;
    }

    /// <summary>
    /// Factory method for a clothes donation.
    /// </summary>
    public static Donation Clothes(string description, int quantity)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description cannot be empty.", nameof(description));

        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));

        return new Donation(DonationType.Clothes, description, quantity, null);
    }

    /// <summary>
    /// Factory method for a food donation.
    /// </summary>
    public static Donation Food(string description, int quantity)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description cannot be empty.", nameof(description));

        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));

        return new Donation(DonationType.Food, description, quantity, null);
    }

    /// <summary>
    /// Factory method for a financial donation.
    /// </summary>
    public static Donation Financial(decimal amount, string description = null)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.", nameof(amount));

        return new Donation(DonationType.Financial, description ?? "Financial donation", null, amount);
    }

    public override string ToString()
    {
        return Type switch
        {
            DonationType.Clothes => $"{Quantity}x {Description} (Clothes donation)",
            DonationType.Food => $"{Quantity}x {Description} (Food donation)",
            DonationType.Financial => $"{Amount:C} (Financial donation)",
            _ => "Unknown donation"
        };
    }
}
