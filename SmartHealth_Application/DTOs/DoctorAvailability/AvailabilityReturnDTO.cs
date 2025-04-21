namespace SmartHealth_Application.DTOs.DoctorAvailability;

public record AvailabilityReturnDTO
{
   public List<WorkingHoursDTO> WorkingHours { get; init; }
   public List<SlotsTaken> SlotsTaken { get; init; }
};