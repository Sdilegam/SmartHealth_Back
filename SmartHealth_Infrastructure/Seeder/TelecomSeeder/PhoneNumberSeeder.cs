using Bogus;
using SmartHealth_Domain.Entities;
using SmartHealth_Domain.Enums;

namespace SmartHealth_Infrastructure.Seeder.TelecomSeeder;

public class PhoneNumberSeeder : Faker<Telecom>
{
    public PhoneNumberSeeder():base("fr")
    {
        UseSeed(42);
        RuleFor(telecom => telecom.TelecomValue, faker => faker.Phone.PhoneNumber("#### ######"));
        RuleFor(telecom => telecom.Scope, faker => faker.PickRandom<ScopeEnum>());
        RuleFor(telecom => telecom.Type, _ => TelecomsTypeEnum.PhoneNumber);
    }
}