namespace SmartHealth_Application.DTOs.DoctorAvailability;

public record AvailabilityReturnDTO
{
   public string doctorName { get; init; }
   public List<WorkingHoursDTO> WorkingHours { get; init; }
   public List<SlotsTaken> SlotsTaken { get; init; }
};