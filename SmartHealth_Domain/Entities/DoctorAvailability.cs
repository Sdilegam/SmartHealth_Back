using SmartHealth_Domain.Enums;

namespace SmartHealth_Domain.Entities;

public record DoctorAvailability
{
    public int DoctorAvailabilityID { get; init; }
    public DaysOfWeekEnum Days { get; init; }
    public TimeOnly StartTime { get; init; }
    public TimeOnly EndTime { get; init; }
    public DateTime ValidtyStart { get; init; }
    public DateTime? ValidtyEnd { get; init; }
};