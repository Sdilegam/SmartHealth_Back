namespace SmartHealth_Domain.Entities;

public record Address
{
    // ReSharper disable once InconsistentNaming
    public int AddressID { get; init; }
    public string Street { get; init; } = null!;
    public string Number { get; init; } = null!;
    public string City { get; init; } = null!;
    public string Zip { get; init; } = null!;
    public string Country { get; init; } = null!;
    public bool IsDeleted { get; init; } = false;
}