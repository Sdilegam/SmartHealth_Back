namespace SmartHealth_Domain.Entities;

public class Address
{
    // ReSharper disable once InconsistentNaming
    public int AddressID { get; set; }
    public string Street { get; set; } = null!;
    public string Number { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Zip { get; set; } = null!;
    public string Country { get; set; } = null!;
    public bool IsDeleted { get; set; } = false;
}