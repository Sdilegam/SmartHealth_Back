using Bogus;
using SmartHealth_Domain.Entities;

namespace SmartHealth_Infrastructure.Seeder.AddressesSeeder;

public class AddressesSeeder:Faker<Address>
{
    public AddressesSeeder():base("fr")
    {
        UseSeed(42);
        RuleFor(address => address.Street, f => f.Address.StreetName());
        RuleFor(address => address.Number, f => f.Address.BuildingNumber());
        RuleFor(address => address.City, f => f.Address.City());
        RuleFor(address => address.Zip, f => f.Address.ZipCode());
        RuleFor(address => address.Country, f => f.Address.Country());
    }
}