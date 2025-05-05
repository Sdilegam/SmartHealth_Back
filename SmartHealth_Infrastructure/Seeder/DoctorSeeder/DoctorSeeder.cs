using Bogus;
using SmartHealth_Domain.Entities;
using SmartHealth_Domain.Enums;
using SmartHealth_Infrastructure.Seeder.AddressesSeeder;
using SmartHealth_Infrastructure.Seeder.AppointmentsSeeder;
using SmartHealth_Infrastructure.Seeder.LoginSeeder;
using SmartHealth_Infrastructure.Seeder.PatientSeeder;
using SmartHealth_Infrastructure.Seeder.TelecomSeeder;

namespace SmartHealth_Infrastructure.Seeding.DoctorSeeder;

public class DoctorSeeder: Faker<Doctor>
{
    private EmailSeeder emailSeeder = new(); 
    private PhoneNumberSeeder phoneNumberSeeder = new(); 
    private AddressesSeeder addressesSeeder = new();
    private LoginSeeder loginSeeder = new(RolesEnum.Doctor);
    private AvailabilitySeeder availabilitySeeder = new();
    private AvailabilitySeeder availabilitySeeder2 = new(1);
    private PatientSeeder patientSeeder = new();
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
        RuleFor(doctor => doctor.Login, (faker, d) => loginSeeder.RuleFor(l=>l.Email, f=>f.Internet.Email(d.FirstName, d.LastName))
            .RuleFor(l=>l.Username, _=> "DR" + d.LastName + d.FirstName.ToUpper()[0] )
            .Generate());
        RuleFor(doctor => doctor.Avatar, f => f.Internet.Avatar());
        RuleFor(doctor => doctor.Availability, _ => [availabilitySeeder.Generate(), availabilitySeeder2.Generate()]);
        RuleFor(doctor => doctor.Appointments, _ => new AppointmentsSeeder(patientSeeder).Generate(20));
        RuleFor(doctor => doctor.Speciality, f => f.Random.Enum<DoctorSpeciality>());
    }
}