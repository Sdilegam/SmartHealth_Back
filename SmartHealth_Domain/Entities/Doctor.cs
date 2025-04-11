namespace SmartHealth_Domain.Entities;

public record Doctor
{
    public int DoctorId { get; init; }
    public string FirstName{ get; init; } = null!;
    public string LastName{ get; init; } = null!;
    public List<Telecom> Telecoms { get; init; } = null!;
    public Address ProfessionalAddress { get; init; } = null!;
    public Address PersonalAddress { get; init; } = null!;
    public Login Login { get; init; } = null!;
}
