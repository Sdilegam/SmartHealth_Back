namespace SmartHealth_Application.DTOs.Doctor;

public record DoctorSearchDTO
{
    public string? Multi { get; init; }
    public string? Name { get; init; }
    public string? Zipcode { get; init; }
};