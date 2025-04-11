using SmartHealth_Application.DTOs.Address;

namespace SmartHealth_Application.DTOs.Doctor;

public class DoctorListDTO
{
    public int DoctorID { get; init; }
    public string Avatar { get; init; } = null!;
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public AddressDTO Address { get; init; } = null!;
}