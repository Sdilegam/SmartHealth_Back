using SmartHealth_Application.Interfaces.Repositories;
using SmartHealth_Domain.Entities;

namespace SmartHealth_Infrastructure.Repository;

public class MedecineRepository(SmartHealthContext context) : BaseRepository<Medecine>(context), IMedecineRepository
{
    public Medecine Add(Appointment appointment, NewMedecineDTO medecineDto)
    {
        Medecine medecineToReturn = context.Medecines.Add(new Medecine()
        {
            Patient = appointment.Patient,
            Doctor = appointment.Doctor,
            Appointment = appointment,
            isBought = false,
            Date = DateTime.Now,
            Instructions = medecineDto.instructions,
            Name = medecineDto.name,
            Quantity = medecineDto.quantity,
        }).Entity;
        context.SaveChanges();
        return medecineToReturn;;
    }

    public List<Medecine> getAllFromAppointment(Appointment appointment)
    {
        return context.Medecines.Where(m => m.Appointment == appointment).ToList();
    }
}