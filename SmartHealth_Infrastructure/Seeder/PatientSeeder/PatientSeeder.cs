using Bogus;
using SmartHealth_Domain.Entities;
using SmartHealth_Domain.Enums;

namespace SmartHealth_Infrastructure.Seeder.PatientSeeder;

public class PatientSeeder:Faker<Patient>
{
    private LoginSeeder.LoginSeeder loginSeeder = new(RolesEnum.Patient);
    private AddressesSeeder.AddressesSeeder addressesSeeder = new();
    public PatientSeeder():base("fr")
    {
        UseSeed(42);
        RuleFor(patient => patient.Login, f => loginSeeder.Generate());
        RuleFor(patient => patient.FirstName, f => f.Name.FirstName());
        RuleFor(patient => patient.LastName, f => f.Name.LastName());
        RuleFor(patient => patient.PersonalAdress, f => addressesSeeder.Generate());
    }
}