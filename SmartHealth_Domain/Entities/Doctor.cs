using SmartHealth_Domain.Enums;

namespace SmartHealth_Domain.Entities;

public record Doctor
{
    public int DoctorId { get; set; }
    public string INAMI { get; set; }
    public string Avatar { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateOnly BirthDate { get; set; }
    public List<Telecom> Telecoms { get; set; } = null!;
    public Address ProfessionalAddress { get; set; } = null!;
    public Address PersonalAddress { get; set; } = null!;
    public LanguagesEnum LanguageSpoken { get; set; }
    public Login Login { get; set; } = null!;
    public GenderEnum Gender { get; set; }
    public List<DoctorAvailability> Availability { get; set; } = null!;
    public List<Appointment> Appointments { get; set; }
    public DoctorSpeciality Speciality { get; set; }
}