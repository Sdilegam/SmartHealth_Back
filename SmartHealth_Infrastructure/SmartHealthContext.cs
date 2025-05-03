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
          AddressesSeeder addressSeeder = new ();
            var patientZero = context.Set<Patient>().FirstOrDefault(patient => patient.PatientID == 1);
            if (patientZero == null)
            {
                Faker<Login> patientLoginFaker = new();
                patientLoginFaker.UseSeed(42)
                    .RuleFor(l=>l.Email, _ => "patientadmin@test.be")
                    .RuleFor(l=>l.SaltKey, _ => Guid.NewGuid())
                    .RuleFor(l=>l.Username, _=>"PatientAdmin")
                    .RuleFor(l=>l.Role, _=>RolesEnum.Patient)
                    .RuleFor(l=>l.Password, (_, l) => PasswordUtils.HashPassword("Admin", l.SaltKey));
                Patient patientAdmin = new()
                {
                    Login = patientLoginFaker.Generate(),
                    Appointments = [],
                    FirstName = "Salvatore",
                    LastName = "Di Legami",
                    PersonalAdress = addressSeeder.Generate(),
                };
                context.Set<Patient>().Add(patientAdmin);
                context.Set<Patient>().AddRange(patientSeeder.Generate(10));
            }
            
            var firstDoctor = context.Set<Doctor>().FirstOrDefault(doctor => doctor.DoctorId == 1);
            if (firstDoctor == null)
            {
                Faker<Login> doctorLoginFaker = new();
                
                doctorLoginFaker.UseSeed(42)
                    .RuleFor(l=>l.Email, _ => "doctoradmin@test.be")
                    .RuleFor(l=>l.SaltKey, _ => Guid.NewGuid())
                    .RuleFor(l=>l.Username, _=>"DoctorAdmin")
                    .RuleFor(l=>l.Role, _=>RolesEnum.Doctor)
                    .RuleFor(l=>l.Password, (_, l) => PasswordUtils.HashPassword("Admin", l.SaltKey));
                Doctor doctorAdmin = new()
                {
                    Login = doctorLoginFaker.Generate(),
                    Appointments = [],
                    FirstName = "Salvatore",
                    LastName = "Di Legami",
                    Availability = [],
                    INAMI = "dsadasf",
                    Avatar = "",
                    LanguageSpoken = LanguagesEnum.French,
                    PersonalAddress = addressSeeder.Generate(),
                    ProfessionalAddress = addressSeeder.Generate(),
                    Telecoms = []
                };
                context.Set<Doctor>().Add(doctorAdmin);
                context.Set<Doctor>().AddRange(doctorSeeder.Generate(10));
            }
            
            context.SaveChanges();
        });
    }
}