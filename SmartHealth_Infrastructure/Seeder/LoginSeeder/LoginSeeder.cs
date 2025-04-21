using Bogus;
using SmartHealth_Domain.Entities;

namespace SmartHealth_Infrastructure.Seeder.LoginSeeder;

public class LoginSeeder:Faker<Login>
{
    public LoginSeeder():base("fr")
    {
        UseSeed(42);
        RuleFor(login => login.Email, f => f.Internet.Email());
        RuleFor(login => login.Username, f => f.Internet.UserName());
        RuleFor(login => login.Password, f => f.Internet.Password());
    }
}