using SmartHealth_Application.DTOs.Appointment;
using SmartHealth_Domain.Entities;

namespace SmartHealth_Application.Interfaces.Services;

public interface IAppointmentService
{
    public List<AppointmentListDTO> GetAll(int userID, string role);

    public Appointment CreateAppointment(int patientID, int doctorID, NewAppointmentDTO appointment);
    public void cancelAppointment(int patientID, int appointmentID);
}