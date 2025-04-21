using Bogus;
using SmartHealth_Domain.Entities;
using SmartHealth_Domain.Enums;

namespace SmartHealth_Infrastructure.Seeding.DoctorSeeder;

public class AvailabilitySeeder:Faker<DoctorAvailability>
{
    public AvailabilitySeeder():base("fr")
    {
        UseSeed(42);
        RuleFor(a => a.Days, _ => (DaysOfWeekEnum)31);
        RuleFor(a=>a.StartTime, f=>f.Date.BetweenTimeOnly(new TimeOnly(6, 0), new TimeOnly(10, 0)));
        RuleFor(a=>a.EndTime, f=>f.Date.BetweenTimeOnly(new TimeOnly(15, 0), new TimeOnly(22, 0)));
        RuleFor(a => a.ValidtyStart, _ => DateTime.Today.AddDays(-5));
        RuleFor(a=>a.ValidtyEnd, _ => DateTime.Today.AddDays(4));
    }
    public AvailabilitySeeder(int _):base("fr")
    {
        UseSeed(43);
        RuleFor(a => a.Days, _ => (DaysOfWeekEnum)31);
        RuleFor(a=>a.StartTime, f=>f.Date.BetweenTimeOnly(new TimeOnly(7, 0), new TimeOnly(11, 0)));
        RuleFor(a=>a.EndTime, f=>f.Date.BetweenTimeOnly(new TimeOnly(16, 0), new TimeOnly(18, 0)));
        RuleFor(a => a.ValidtyStart, _ => DateTime.Today.AddDays(4));
    }
}