using SmartHealth_Application.DTOs.Address;
using SmartHealth_Domain.Enums;

namespace SmartHealth_Application.DTOs.Doctor;

public record DoctorListDTO
{
    public int DoctorID { get; init; }
    public string Avatar { get; init; } = null!;
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public AddressDTO Address { get; init; } = null!;
    public string PhoneNumber { get; set; } = null;
    public string Email { get; set; } = null;
    public LanguagesEnum LanguageSpoken { get; init; }

}