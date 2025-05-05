using Bogus;
using SmartHealth_Domain.Entities;
using SmartHealth_Domain.Enums;

namespace SmartHealth_Infrastructure.Seeder.AppointmentsSeeder;

public class AppointmentsSeeder: Faker<Appointment>
{
    private int index = 0;

    public AppointmentsSeeder(PatientSeeder.PatientSeeder patientSeeder):base("fr")
    {
        UseSeed(42);
        RuleFor(a=>a.Patient, _ => patientSeeder.Generate());
        RuleFor(a=> a.StartTime, f => DateTime.Today.AddDays(index++%5).AddHours(f.Random.Int(9,17)).AddMinutes(f.Random.Int(0,1) * 30));
        RuleFor(a=> a.EndTime, (f, a) => a.StartTime.AddMinutes(30));
        RuleFor(a=> a.Status, f => f.PickRandom<AppointmentStatusEnum>());
        RuleFor(a=>a.Type,  f => f.PickRandom<AppointmentTypeEnum>());
    }
}