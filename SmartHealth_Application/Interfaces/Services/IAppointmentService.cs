using SmartHealth_Application.DTOs.Appointment;
using SmartHealth_Domain.Entities;

namespace SmartHealth_Application.Interfaces.Services;

public interface IAppointmentService
{
    List<AppointmentListDTO> GetAll(int userID, string role);
    Appointment CreateAppointment(int patientID, int doctorID, NewAppointmentDTO appointment);
    void cancelAppointment(int patientID, int appointmentID);
    AppointmentDetailsDTO getAppointmentDetails(int appointmentId, int userId);
}