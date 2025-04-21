using SmartHealth_Domain.Enums;

namespace SmartHealth_Domain.Entities;

public record Doctor
{
    public int DoctorId { get; init; }
    public string INAMI { get; init; }
    public string Avatar { get; init; } = null!;
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public List<Telecom> Telecoms { get; init; } = null!;
    public Address ProfessionalAddress { get; init; } = null!;
    public Address PersonalAddress { get; init; } = null!;
    public LanguagesEnum LanguageSpoken { get; init; }
    public Login Login { get; init; } = null!;
    public List<DoctorAvailability> Availability { get; init; } = null!;
    public List<Appointment> Appointments { get; init; }
}