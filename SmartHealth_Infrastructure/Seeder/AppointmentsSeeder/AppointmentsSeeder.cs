using Bogus;
using SmartHealth_Domain.Entities;
using SmartHealth_Domain.Enums;

namespace SmartHealth_Infrastructure.Seeder.AppointmentsSeeder;

public class AppointmentsSeeder: Faker<Appointment>
{
    private int index = 0;
    private PatientSeeder.PatientSeeder patientSeeder = new();

    public AppointmentsSeeder():base("fr")
    {
        UseSeed(42);
        RuleFor(a=>a.Patient, _ => patientSeeder.Generate());
        RuleFor(a=>a.Duration, _ => new TimeSpan(00, 30, 00));
        RuleFor(a => a.StartTime, f => f.Date.Between(DateTime.Today.AddDays(index).AddHours(8), DateTime.Today.AddDays(index++).AddHours(18)));
        RuleFor(a => a.Status, f => f.PickRandom<AppointmentStatusEnum>());
        RuleFor(a=>a.Type,  f => f.PickRandom<AppointmentTypeEnum>());
    }
}