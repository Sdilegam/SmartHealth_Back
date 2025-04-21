using Bogus;
using SmartHealth_Domain.Entities;
using SmartHealth_Domain.Enums;
using SmartHealth_Infrastructure.Seeder.AddressesSeeder;
using SmartHealth_Infrastructure.Seeder.AppointmentsSeeder;
using SmartHealth_Infrastructure.Seeder.LoginSeeder;
using SmartHealth_Infrastructure.Seeder.TelecomSeeder;

namespace SmartHealth_Infrastructure.Seeding.DoctorSeeder;

public class DoctorSeeder: Faker<Doctor>
{
    private EmailSeeder emailSeeder = new(); 
    private PhoneNumberSeeder phoneNumberSeeder = new(); 
    private AddressesSeeder addressesSeeder = new();
    private LoginSeeder loginSeeder = new();
    private AvailabilitySeeder availabilitySeeder = new();
    private AvailabilitySeeder availabilitySeeder2 = new(1);
    public DoctorSeeder():base("fr")
    {
        UseSeed(42);
        RuleFor(doctor => doctor.INAMI, f => f.Hashids.ToString());
        RuleFor(doctor => doctor.LanguageSpoken,
            f => (LanguagesEnum)(f.Random.EnumValues<LanguagesEnum>(3).Sum(t => (int)t)));
        RuleFor(doctor => doctor.FirstName, f => f.Name.FirstName());
        RuleFor(doctor => doctor.LastName, f => f.Name.LastName());
        RuleFor(doctor => doctor.Telecoms, _ =>
        {
            var list = emailSeeder.Generate(4);
            list.AddRange(phoneNumberSeeder.Generate(4));
            return list;
        });
        RuleFor(doctor => doctor.ProfessionalAddress, _ => addressesSeeder.Generate());
        RuleFor(doctor => doctor.PersonalAddress, _ => addressesSeeder.Generate());
        RuleFor(doctor => doctor.Login, faker => loginSeeder.Generate());
        RuleFor(doctor => doctor.Avatar, f => f.Internet.Avatar());
        RuleFor(doctor => doctor.Availability, _ => [availabilitySeeder.Generate(), availabilitySeeder2.Generate()]);
        RuleFor(doctor => doctor.Appointments, _ => new AppointmentsSeeder().Generate(10));
    }
}