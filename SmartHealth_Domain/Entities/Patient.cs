using SmartHealth_Domain.Enums;

namespace SmartHealth_Domain.Entities;

public record Patient
{
    // ReSharper disable once InconsistentNaming
    public int PatientID { get; set; }
    public DateOnly BirthDate { get; set; }
    public string LastName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public Address PersonalAdress { get; set; } = null!;
    public Login Login { get; set; } = null!;
    public GenderEnum Gender { get; set; }
    public string? PhoneNumber { get; set; } = null!;
    public List<Appointment> Appointments { get; set; } = null!;
}