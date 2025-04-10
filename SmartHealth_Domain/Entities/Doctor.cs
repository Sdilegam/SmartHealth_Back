namespace SmartHealth_Domain.Entities;

public record Doctor
{
    public int DoctorId { get; init; }
    public string FirstName{ get; init; }
    public string LastName{ get; init; }
    public List<Telecom> Telecoms { get; init; }
}
