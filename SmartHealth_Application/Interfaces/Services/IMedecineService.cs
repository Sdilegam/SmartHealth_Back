using SmartHealth_Application.DTOs.Medecine;

namespace SmartHealth_Application.Interfaces.Services;

public interface IMedecineService
{
    MedecineListDTO AddFromAppointment(int userId, int appointmentId, NewMedecineDTO medecineDto);
    List<MedecineListDTO> AllFromAppointment(int userId, int appointmentId);
}