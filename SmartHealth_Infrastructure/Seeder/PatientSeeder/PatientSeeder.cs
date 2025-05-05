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
        RuleFor(patient => patient.FirstName, f => f.Name.FirstName());
        RuleFor(patient => patient.LastName, f => f.Name.LastName());
        RuleFor(patient => patient.Login, (faker, p) => loginSeeder.RuleFor(l=>l.Email, f=>f.Internet.Email(p.FirstName, p.LastName))
            .RuleFor(l=>l.Username, _=> p.LastName + p.FirstName.ToUpper()[0] )
            .Generate());
        RuleFor(patient => patient.PersonalAdress, f => addressesSeeder.Generate());
    }
}