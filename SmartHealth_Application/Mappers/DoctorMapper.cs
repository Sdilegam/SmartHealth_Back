using SmartHealth_Application.DTOs.Doctor;
using SmartHealth_Domain.Entities;

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
}