using SmartHealth_Application.DTOs.Patient;
using SmartHealth_Application.Interfaces.Repositories;
using SmartHealth_Application.Interfaces.Services;
using SmartHealth_Application.Mappers;
using SmartHealth_Domain.Entities;

namespace SmartHealth_Application.Services;

public class PatientService(IPatientRepository patientRepository):IPatientService
{
    public PatientUserViewModel GetPatientInfo(int loginID)
    {
        Patient? patient =  patientRepository.GetPatientByLoginID(loginID);
        PatientUserViewModel vmToReturn = patient.ToPatientUserVM();

        return vmToReturn;
    }
}