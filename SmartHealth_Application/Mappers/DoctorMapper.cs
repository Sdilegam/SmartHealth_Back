using SmartHealth_Application.DTOs.Doctor;
using SmartHealth_Application.DTOs.Patient;
using SmartHealth_Domain.Entities;
using SmartHealth_Domain.Enums;

namespace SmartHealth_Application.Mappers;

public static class DoctorMapper
{
    public static DoctorListDTO ToDoctorListDTO(this Doctor entity, string? email = null, string? phoneNumber=null)
    {
        DoctorListDTO DTOToReturn = new()
        {
            DoctorID = entity.DoctorId,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Address = entity.ProfessionalAddress.ToDTO(),
            Avatar = entity.Avatar,
            Email = email,
            PhoneNumber = phoneNumber,
            LanguageSpoken = entity.LanguageSpoken,
            Speciality = entity.Speciality
        };
        return DTOToReturn;
    } 
    public static UserViewModel ToPatientUserVM(this Doctor doctor)
    {
        UserViewModel userViewModel = new()
        {
            Address = doctor.PersonalAddress.ToDTO(),
            BirthDate = doctor.BirthDate,
            DisplayName = doctor.FirstName + " " + doctor.LastName,
            FirstName = doctor.FirstName,
            LastName = doctor.LastName,
            Email = doctor.Login.Email,
            gender = doctor.Gender,
            PhoneNumber = doctor.Telecoms.FirstOrDefault(t=>t.Type==TelecomsTypeEnum.PhoneNumber).TelecomValue,
        };
        return userViewModel;
    }
}