using SmartHealth_Application.DTOs.Patient;

namespace SmartHealth_Application.Interfaces.Services;

public interface IPatientService
{
    public UserViewModel GetPatientInfo(int loginID);
}