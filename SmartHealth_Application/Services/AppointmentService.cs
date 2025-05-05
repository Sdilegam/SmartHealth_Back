using SmartHealth_Application.DTOs.Appointment;
using SmartHealth_Application.Interfaces.Repositories;
using SmartHealth_Application.Interfaces.Services;
using SmartHealth_Application.Mappers;
using SmartHealth_Domain.Entities;

namespace SmartHealth_Application.Services;

public class AppointmentService(IAppointmentRepository appointmentRepository, IDoctorRepository doctorRepository, IPatientRepository patientRepository, IAuthRepository authRepository): IAppointmentService
{
    public List<AppointmentListDTO> GetAll(int userID, string role)
    {
        List<Appointment> appointments = null!;
        if (role == "Patient")
        {
            Patient? user = authRepository.getPatientFromLogin(userID);
            appointments = appointmentRepository.GetAll(user);
        }
        else
        {
            Doctor? user = authRepository.getDoctorFromLogin(userID);
            appointments = appointmentRepository.GetAll(user);
        }
        return appointments.Select(appointment=>appointment.ToAppointmentListDTO()).ToList();
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

    public AppointmentDetailsDTO? getAppointmentDetails(int appointmentId, int userID)
    {
        Appointment app = null!;
        Patient? patient = authRepository.getPatientFromLogin(userID);
        if (patient is null)
        {
            Doctor? doctor = authRepository.getDoctorFromLogin(userID);
            if (doctor is null) throw new System.Exception("Could not identify user");
            else
            {
                app = appointmentRepository.FindOneWhere(a=>a.AppointmentID == appointmentId && a.Doctor ==  doctor);
            }
        }
        else
        {
            app = appointmentRepository.FindOneWhere(a=>a.AppointmentID == appointmentId && a.Patient ==  patient);
        }
        if (app is null) throw new Exception("Appointment not found");
        return (app.ToAppointmentDetailsDTO());
    }
}