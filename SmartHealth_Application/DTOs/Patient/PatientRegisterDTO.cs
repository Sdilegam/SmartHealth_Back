using SmartHealth_Application.DTOs.Address;
using SmartHealth_Domain.Enums;

namespace SmartHealth_Application.DTOs;

public record PatientRegisterDTO
{
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public string PhoneNumber { get; init; } = null!;
    public string Email { get; init; } = null!;
    public AddressDTO Address { get; init; } = null!;
    public GenderEnum Gender { get; set; }
}