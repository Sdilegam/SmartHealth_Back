using SmartHealth_Application.DTOs.Patient;
using SmartHealth_Domain.Entities;

namespace SmartHealth_Application.Mappers;

public static class PatientMapper
{
    public static PatientUserViewModel ToPatientUserVM(this Patient patient)
    {
        PatientUserViewModel patientUserViewModel = new()
        {
            Address = patient.PersonalAdress.ToDTO(),
            BirthDate = patient.BirthDate,
            DisplayName = patient.FirstName + " " + patient.LastName,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            Email = patient.Login.Email,
            gender = patient.Gender,
            PhoneNumber = patient.PhoneNumber,
        };
        return patientUserViewModel;
    }
}