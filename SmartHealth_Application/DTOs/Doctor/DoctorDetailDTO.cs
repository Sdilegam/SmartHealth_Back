using SmartHealth_Application.DTOs.Address;
using SmartHealth_Domain.Enums;

namespace SmartHealth_Application.DTOs.Doctor;

public record DoctorDetailDTO
{
 public int DoctorID { get; set; }
 public string Avatar { get; set; }
 public string FirstName { get; init; } = null!;
 public string LastName { get; init; } = null!;
 public AddressDTO Address { get; init; } = null!;
 public string PhoneNumber { get; set; } = null;
 public string Email { get; set; } = null;
 public DoctorSpeciality Speciality { get; init; }

}