using SmartHealth_Application.DTOs.Doctor;

namespace SmartHealth_Application.Interfaces.Services;

public interface IDoctorService
{
    public List<DoctorListDTO> GetAll(DoctorSearchDTO? searchDTO);
}