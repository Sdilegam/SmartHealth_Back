using Microsoft.EntityFrameworkCore;
using SmartHealth_Domain.Entities;
using SmartHealth_Infrastructure.Configs;

namespace SmartHealth_Infrastructure;

public class SmartHealthContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Patient> Patients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AddressConfig());
        modelBuilder.ApplyConfiguration(new PatientConfig());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSeeding((context, _) =>
        {
            var firstAddress = context.Set<Address>().FirstOrDefault(address => address.AddressID == 1);

            if (firstAddress == null)
            {
                firstAddress = context.Set<Address>().Add(new Address()
                {
                    Street = "Main St",
                    Number = "12345",
                    City = "Main City",
                    Country = "United States",
                    Zip = "1080"
                }).Entity;
            }
            context.SaveChanges();

            var patientZero = context.Set<Patient>().FirstOrDefault(patient => patient.PatientID == 1);
            if (patientZero == null)
            {
                context.Set<Patient>().Add(new Patient()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    PersonalAdress = firstAddress
                });
            }

            context.SaveChanges();
        })
            .UseAsyncSeeding(async (context, _, CancellationToken) =>
        {
            var firstAddress = context.Set<Address>().FirstOrDefault(address => address.AddressID == 1);

            if (firstAddress == null)
            {
                firstAddress = context.Set<Address>().Add(new Address()
                {
                    Street = "Main St",
                    Number = "12345",
                    City = "Main City",
                    Country = "United States",
                    Zip = "1080"
                }).Entity;
            }
            await context.SaveChangesAsync(CancellationToken);

            var patientZero = context.Set<Patient>().FirstOrDefault(patient => patient.PatientID == 1);
            if (patientZero == null)
            {
                context.Set<Patient>().Add(new Patient()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    PersonalAdress = firstAddress
                });
            }
            await context.SaveChangesAsync(CancellationToken);
        });
    }
}