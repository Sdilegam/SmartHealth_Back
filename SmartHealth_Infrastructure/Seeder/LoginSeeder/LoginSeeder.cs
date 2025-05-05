using Bogus;
using IntermediateLab_Backend.Application.Utils;
using SmartHealth_Domain.Entities;
using SmartHealth_Domain.Enums;

namespace SmartHealth_Infrastructure.Seeder.LoginSeeder;

public class LoginSeeder:Faker<Login>
{
    public LoginSeeder(RolesEnum role):base("fr")
    {
        UseSeed(42);
        RuleFor(login => login.SaltKey, _=>Guid.NewGuid());
        RuleFor(login => login.Password, (f, u) => PasswordUtils.HashPassword("Test", u.SaltKey));
        RuleFor(l => l.Role, _ => role);
    }
}