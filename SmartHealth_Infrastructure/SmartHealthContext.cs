using Bogus;
using Microsoft.EntityFrameworkCore;
using SmartHealth_Domain.Entities;
using SmartHealth_Domain.Enums;
using SmartHealth_Infrastructure.Configs;

namespace SmartHealth_Infrastructure;

public class SmartHealthContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Telecom> Telecoms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AddressConfig());
        modelBuilder.ApplyConfiguration(new PatientConfig());
        modelBuilder.Entity<Patient>().Navigation(patient => patient.PersonalAdress).AutoInclude();
        modelBuilder.Entity<Doctor>().Navigation(doctor => doctor.ProfessionalAddress).AutoInclude();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSeeding((context, _) =>
        {
            Faker<Address>? addressFaker = new Faker<Address>().UseSeed(42)
                .RuleFor(address => address.Street, f => f.Address.StreetName())
                .RuleFor(address => address.Number, f => f.Address.BuildingNumber())
                .RuleFor(address => address.City, f => f.Address.City())
                .RuleFor(address => address.Zip, f => f.Address.ZipCode())
                .RuleFor(address => address.Country, f => f.Address.Country());
            List<Address> addresses = addressFaker.Generate(20);
            var firstAddress = context.Set<Address>().FirstOrDefault(address => address.AddressID == 1);
            if (firstAddress == null)
            {
                context.Set<Address>().AddRange(addresses);
            }

            Faker<Login>? loginFaker = new Faker<Login>().UseSeed(42)
                .RuleFor(login => login.Email, f => f.Internet.Email())
                .RuleFor(login => login.Username, f => f.Internet.UserName())
                .RuleFor(login => login.Password, f => f.Internet.Password());
            Faker<Patient>? patientFaker = new Faker<Patient>().UseSeed(42)
                .RuleFor(patient => patient.Login,  f => loginFaker.Generate())
                .RuleFor(patient => patient.FirstName, f => f.Name.FirstName())
                .RuleFor(patient => patient.LastName, f => f.Name.LastName())
                .RuleFor(patient => patient.PersonalAdress, f => f.Random.ListItem(addresses));
            var patientZero = context.Set<Patient>().FirstOrDefault(patient => patient.PatientID == 1);
            if (patientZero == null)
            {
                context.Set<Patient>().AddRange(patientFaker.Generate(10));
            }

            Faker<Telecom>? telecomFaker = new Faker<Telecom>().UseSeed(42)
                .RuleFor(telecom => telecom.TelecomValue, faker => faker.Internet.Email())
                .RuleFor(telecom => telecom.Scope, faker => faker.PickRandom<ScopeEnum>())
                .RuleFor(telecom => telecom.Type, faker => faker.PickRandom<TelecomsTypeEnum>());

            Faker<Doctor>? doctorFaker = new Faker<Doctor>().UseSeed(42)
                .RuleFor(doctor => doctor.FirstName, f => f.Name.FirstName())
                .RuleFor(doctor => doctor.LastName, f => f.Name.LastName())
                .RuleFor(doctor => doctor.Telecoms, _ => telecomFaker.Generate(4))
                .RuleFor(doctor => doctor.ProfessionalAddress, _ => addressFaker.Generate())
                .RuleFor(doctor => doctor.PersonalAddress, _ => addressFaker.Generate())
                .RuleFor(doctor => doctor.Login, faker => loginFaker.Generate())
                .RuleFor(doctor => doctor.Avatar, f => f.Internet.Avatar());
            
            var firstDoctor = context.Set<Doctor>().FirstOrDefault(doctor => doctor.DoctorId == 1);
            if (firstDoctor == null)
            {
                context.Set<Doctor>().AddRange(doctorFaker.Generate(10));
            }
            
            context.SaveChanges();
        });
        //     .UseAsyncSeeding(async (context, _, CancellationToken) =>
        // {
        //     var firstAddress = context.Set<Address>().FirstOrDefault(address => address.AddressID == 1);
        //
        //     if (firstAddress == null)
        //     {
        //         firstAddress = context.Set<Address>().Add(new Address()
        //         {
        //             Street = "Main St",
        //             Number = "12345",
        //             City = "Main City",
        //             Country = "United States",
        //             Zip = "1080"
        //         }).Entity;
        //     }
        //     await context.SaveChangesAsync(CancellationToken);
        //
        //     var patientZero = context.Set<Patient>().FirstOrDefault(patient => patient.PatientID == 1);
        //     if (patientZero == null)
        //     {
        //         context.Set<Patient>().Add(new Patient()
        //         {
        //             FirstName = "John",
        //             LastName = "Doe",
        //             PersonalAdress = firstAddress
        //         });
        //     }
        //     await context.SaveChangesAsync(CancellationToken);
        // });
    }
}