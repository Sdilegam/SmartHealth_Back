using SmartHealth_Application.DTOs.Address;
using SmartHealth_Domain.Enums;

namespace SmartHealth_Application.DTOs.Doctor;

public record DoctorRegisterDTO
{
    public string FirstName { get; set; } = null;
    public string LastName { get; set; } = null;
    public string INAMI { get; set; }
    public string PhoneNumber { get; set; } = null;
    public string Email { get; set; } = null;
    public AddressDTO Address { get; set; } = null!;
    public GenderEnum Gender { get; set; }
}