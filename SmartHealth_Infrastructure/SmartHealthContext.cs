using Bogus;
using Microsoft.EntityFrameworkCore;
using SmartHealth_Domain.Entities;
using SmartHealth_Domain.Enums;
using SmartHealth_Infrastructure.Configs;
using SmartHealth_Infrastructure.Seeder.AddressesSeeder;
using SmartHealth_Infrastructure.Seeder.PatientSeeder;
using SmartHealth_Infrastructure.Seeding.DoctorSeeder;

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
        modelBuilder.Entity<Doctor>().Navigation(doctor => doctor.Telecoms).AutoInclude();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSeeding((context, _) =>
        {
          PatientSeeder patientSeeder = new ();
          DoctorSeeder doctorSeeder = new ();
            var patientZero = context.Set<Patient>().FirstOrDefault(patient => patient.PatientID == 1);
            if (patientZero == null)
            {
                context.Set<Patient>().AddRange(patientSeeder.Generate(10));
            }
            
            var firstDoctor = context.Set<Doctor>().FirstOrDefault(doctor => doctor.DoctorId == 1);
            if (firstDoctor == null)
            {
                context.Set<Doctor>().AddRange(doctorSeeder.Generate(10));
            }
            
            context.SaveChanges();
        });
    }
}