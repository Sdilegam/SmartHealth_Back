using SmartHealth_Application.DTOs.Medecine;
using SmartHealth_Application.Interfaces.Repositories;
using SmartHealth_Application.Interfaces.Services;
using SmartHealth_Application.Mappers;
using SmartHealth_Domain.Entities;

namespace SmartHealth_Application.Services;

public class MedecineService (IMedecineRepository medecineRepository, IAuthRepository authRepository, IAppointmentRepository appointmentRepository):IMedecineService
{
    public MedecineListDTO AddFromAppointment(int userId, int appointmentId, NewMedecineDTO medecineDto)
    {
        Doctor? doctor = authRepository.getDoctorFromLogin(userId);
        Appointment? appointment = appointmentRepository.GetByID(appointmentId);
        if (doctor != appointment.Doctor) throw (new Exception("Your are not allowed to do that"));
        return medecineRepository.Add(appointment,medecineDto).ToMedecineListDTO();
    }

    public List<MedecineListDTO> AllFromAppointment(int userId, int appointmentId)
    {
        Doctor? doctor = authRepository.getDoctorFromLogin(userId);
        Appointment? appointment = appointmentRepository.GetByID(appointmentId);
        if(doctor != null && doctor != appointment.Doctor) throw (new Exception("Your are not allowed to do that"));
        else if (doctor == null)
        {
            Patient? patient = authRepository.getPatientFromLogin(userId);
            if (patient != null && appointment.Patient != patient) throw (new Exception("Your are not allowed to do that"));
        }
        return (medecineRepository.getAllFromAppointment(appointment).Select(m=>m.ToMedecineListDTO()).ToList());
    }
}