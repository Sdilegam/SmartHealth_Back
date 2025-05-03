using Microsoft.EntityFrameworkCore;
using SmartHealth_Application.DTOs.Appointment;
using SmartHealth_Application.Interfaces.Repositories;
using SmartHealth_Domain.Entities;
using SmartHealth_Domain.Enums;

namespace SmartHealth_Infrastructure.Repository;

public class AppointmentRepository(SmartHealthContext context): BaseRepository<Appointment>(context), IAppointmentRepository
{
    public List<Appointment> GetAll(Patient patient)
    {
        return(context.Appointments.Include(a=>a.Doctor).Where(a=>a.Patient==patient).ToList());
    }

    public Appointment NewAppointment(Patient patient, Doctor doctor, NewAppointmentDTO appointment)
    {
        DateTime starTime = appointment.Start;
        DateTime endTime = starTime.AddMinutes(appointment.Duration);
        TimeSpan duration = new(0, appointment.Duration, 0);
        Appointment? overlappingEvent = context.Appointments
            .Where(a=>a.Doctor == doctor)
            .FirstOrDefault(a => (a.StartTime < starTime && starTime < a.EndTime) ||
                                 (a.StartTime < endTime && endTime <= a.EndTime)||
                                 (starTime <= a.StartTime && a.EndTime <= endTime));
        if (overlappingEvent != null)
            throw new Exception("Appointment overlapping event");
        Appointment appointmentCreated = new Appointment()
        {
            StartTime = starTime,
            EndTime = endTime,
            Doctor = doctor,
            Patient = patient,
            Status = AppointmentStatusEnum.Scheduled,
            Type = appointment.AppointmentType
        };
        context.Appointments.Add(appointmentCreated);
        context.SaveChanges();
        return appointmentCreated;
    }

    public void cancel(Patient patient, Appointment appointment)
    {
        if (!patient.Appointments.Contains(appointment) ) throw new System.Exception("You are not allowed to cancel this appointment");
        if (appointment.Status != AppointmentStatusEnum.Scheduled) throw new System.Exception("You can only cancel scheduled appointments");
        appointment.Status = AppointmentStatusEnum.Cancelled;
        context.SaveChanges();
    }
}