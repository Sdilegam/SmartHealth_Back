using SmartHealth_Application.DTOs.DoctorAvailability;
using SmartHealth_Domain.Entities;

namespace SmartHealth_Application.Interfaces.Repositories;

public interface IDoctorRepository: IRepositoryBase<Doctor>
{
    public List<WorkingHoursDTO> GetAvailabilityList(int id, AvailabilityRequestRange range);
    public List<SlotsTaken> GetSlotsTaken(int id, AvailabilityRequestRange range);


}