namespace SmartHealth_Application.DTOs.Address;

public record AddressDTO
{
    public string Street { get; init; } = null!;
    public string Number { get; init; } = null!;
    public string City { get; init; } = null!;
    public string Zip { get; init; } = null!;
    public string Country { get; init; } = null!;
};