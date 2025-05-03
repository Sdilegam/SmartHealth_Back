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
            doctor = new (){
             doctorID = entity.Doctor.DoctorId,
             name = "Dr " + entity.Doctor.FirstName +  " " + entity.Doctor.LastName,
        }
        };
        return DTOToReturn;
    } 
}