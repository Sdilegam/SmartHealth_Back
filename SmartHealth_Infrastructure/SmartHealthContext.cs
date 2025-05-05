using Bogus;
using IntermediateLab_Backend.Application.Utils;
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
    public DbSet<Login> Logins { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Telecom> Telecoms { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<DoctorAvailability> Availabilities { get; set; }
    public DbSet<Medecine> Medecines { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AddressConfig());
        modelBuilder.ApplyConfiguration(new PatientConfig());
        modelBuilder.Entity<Patient>().Navigation(patient => patient.PersonalAdress).AutoInclude();
        modelBuilder.Entity<Doctor>().Navigation(patient => patient.PersonalAddress).AutoInclude();
        modelBuilder.Entity<Doctor>().Navigation(doctor => doctor.ProfessionalAddress).AutoInclude();
        modelBuilder.Entity<Doctor>().Navigation(doctor => doctor.Telecoms).AutoInclude();
        modelBuilder.Entity<Doctor>().Navigation(doctor => doctor.Login).AutoInclude();
        modelBuilder.Entity<Appointment>().Navigation(appointment => appointment.Patient).AutoInclude();
        modelBuilder.Entity<Appointment>().Navigation(appointment => appointment.Doctor).AutoInclude();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSeeding((context, _) =>
        {
          DoctorSeeder doctorSeeder = new ();

            var firstDoctor = context.Set<Doctor>().FirstOrDefault(doctor => doctor.DoctorId == 1);
            if (firstDoctor == null)
            {
                Faker<Login> doctorLoginFaker = new();
                context.Set<Doctor>().AddRange(doctorSeeder.Generate(10));
            }
            
            context.SaveChanges();
        });
    }
}