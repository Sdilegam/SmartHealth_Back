using Bogus;
using SmartHealth_Domain.Entities;
using SmartHealth_Domain.Enums;

namespace SmartHealth_Infrastructure.Seeder.TelecomSeeder;

public class EmailSeeder:Faker<Telecom>
{
    public EmailSeeder():base("fr")
    {
        UseSeed(42);
        RuleFor(telecom => telecom.TelecomValue, faker => faker.Internet.Email());
        RuleFor(telecom => telecom.Scope, faker => faker.PickRandom<ScopeEnum>());
        RuleFor(telecom => telecom.Type, _ => TelecomsTypeEnum.EmailAddress);
    }
}