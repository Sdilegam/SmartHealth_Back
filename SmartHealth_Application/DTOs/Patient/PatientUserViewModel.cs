using SmartHealth_Application.DTOs.Address;
using SmartHealth_Domain.Enums;

namespace SmartHealth_Application.DTOs.Patient;

public record PatientUserViewModel
{
    public string DisplayName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public GenderEnum gender { get; set; }
    public AddressDTO Address  { get; set; }
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateOnly BirthDate { get; set; }
}