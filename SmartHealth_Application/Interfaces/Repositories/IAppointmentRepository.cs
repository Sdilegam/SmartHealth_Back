using SmartHealth_Application.DTOs.Appointment;
using SmartHealth_Domain.Entities;

namespace SmartHealth_Application.Interfaces.Repositories;

public interface IAppointmentRepository: IRepositoryBase<Appointment>
{
    public List<Appointment> GetAll(Patient patient);
    public List<Appointment> GetAll(Doctor doctor);
    public Appointment NewAppointment(Patient patient, Doctor doctor, NewAppointmentDTO appointment);
    public void cancel(Patient patient, Appointment appointment);
}