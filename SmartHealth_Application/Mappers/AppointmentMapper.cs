using SmartHealth_Application.DTOs.Appointment;
using SmartHealth_Application.DTOs.Doctor;
using SmartHealth_Domain.Entities;

namespace SmartHealth_Application.Mappers;

public static class AppointmentMapper
{
    public static AppointmentListDTO ToAppointmentListDTO(this Appointment entity)
    {
        AppointmentListDTO DTOToReturn = new()
        {
            appointmentID = entity.AppointmentID,
            startDate = entity.StartTime.ToString("yyyy-MM-dd HH:mm:ss"),
            endDate = entity.EndTime.ToString("yyyy-MM-dd HH:mm:ss"),
            status = entity.Status,
            type = entity.Type,
            doctor = new()
            {
                doctorID = entity.Doctor.DoctorId,
                name = "Dr " + entity.Doctor.FirstName + " " + entity.Doctor.LastName,
            },
            patient = new()
            {
                patientID = entity.Patient.PatientID,
                name = entity.Patient.FirstName + " " + entity.Patient.LastName,
            }
        };
        return DTOToReturn;
    }

    public static AppointmentDetailsDTO ToAppointmentDetailsDTO(this Appointment entity)
    {
        AppointmentDetailsDTO DTOToReturn = new()
        {
            appointmentID = entity.AppointmentID,
            startDate = entity.StartTime.ToString("yyyy-MM-dd HH:mm:ss"),
            endDate = entity.EndTime.ToString("yyyy-MM-dd HH:mm:ss"),
            status = entity.Status,
            type = entity.Type,
            doctor = new()
            {
                doctorID = entity.Doctor.DoctorId,
                name = "Dr " + entity.Doctor.FirstName + " " + entity.Doctor.LastName,
            },
            creationDate = entity.CreationDate.ToString("yyyy-MM-dd HH:mm:ss"),
            doctorsNotes = entity.DoctorsNotes,
            patientsNotes = entity.PatientsNotes,
            realEndTime = entity.RealEndTime?.ToString("yyyy-MM-dd HH:mm:ss"),
            realStartTime = entity.RealStartTime?.ToString("yyyy-MM-dd HH:mm:ss"),
            patient = new()
            {
                patientID = entity.Patient.PatientID,
                name = entity.Patient.FirstName + " " + entity.Patient.LastName,
            },
        };
        return DTOToReturn;
    }
}