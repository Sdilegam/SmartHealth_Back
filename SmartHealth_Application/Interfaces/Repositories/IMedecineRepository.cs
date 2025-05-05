using SmartHealth_Application.DTOs.Medecine;
using SmartHealth_Domain.Entities;

namespace SmartHealth_Application.Interfaces.Repositories;

public interface IMedecineRepository:IRepositoryBase<Medecine>
{
    Medecine Add(Appointment appointment, NewMedecineDTO medecineDto);
    List<Medecine> getAllFromAppointment(Appointment appointment);
}