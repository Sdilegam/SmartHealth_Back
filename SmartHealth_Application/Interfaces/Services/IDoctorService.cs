using SmartHealth_Application.DTOs.Doctor;
using SmartHealth_Application.DTOs.DoctorAvailability;

namespace SmartHealth_Application.Interfaces.Services;

public interface IDoctorService
{
    public List<DoctorListDTO> GetAll(DoctorSearchDTO? searchDTO);
    public AvailabilityReturnDTO GetAvailability(int id, AvailabilityRequestRange range);
}