namespace SmartHealth_Domain.Entities;

public record Patient
{
    // ReSharper disable once InconsistentNaming
    public int PatientID { get; init; }
    public string LastName { get; init; } = null!;
    public string FirstName { get; init; } = null!;
    public Address PersonalAdress { get; init; } = null!;
    public Login Login { get; init; } = null!;
    public List<Appointment> Appointments { get; init; } = null!;
}