using SmartHealth_Application.DTOs.Appointment;
using SmartHealth_Application.Interfaces.Repositories;
using SmartHealth_Application.Interfaces.Services;
using SmartHealth_Application.Mappers;
using SmartHealth_Domain.Entities;

namespace SmartHealth_Application.Services;

public class AppointmentService(IAppointmentRepository appointmentRepository, IDoctorRepository doctorRepository, IPatientRepository patientRepository): IAppointmentService
{
    public List<AppointmentListDTO> GetAll(int ID)
    {
        Patient? patient = patientRepository.GetByID(ID);
        return appointmentRepository.GetAll(patient).Select(appointment=>appointment.ToAppointmentListDTO()).ToList();
    }
    public Appointment CreateAppointment(int patientID, int doctorID, NewAppointmentDTO appointment)
    {
        Appointment appointmentToReturn = null!;
        Doctor doctor = doctorRepository.GetByID(doctorID);
        Patient patient = patientRepository.GetByID(patientID);
        appointmentToReturn = appointmentRepository.NewAppointment(patient, doctor, appointment);
        return appointmentToReturn;
    }

    public void cancelAppointment(int patientLoginID, int appointmentID)
    {
        Patient? patient =  patientRepository.GetPatientByLoginID(patientLoginID);
        if (patient is null) throw new System.Exception("Patient not found");
        Appointment? appointment = appointmentRepository.GetByID(appointmentID);
        if (appointment is null) throw new System.Exception("Appointment not found");
        appointmentRepository.cancel(patient, appointment);
    }
}