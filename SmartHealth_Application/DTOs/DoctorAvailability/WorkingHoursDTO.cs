namespace SmartHealth_Application.DTOs.DoctorAvailability;

public record WorkingHoursDTO
{
    public int[] DaysOfWeek {get; init;}
    public string StartTime {get; init;}
    public string EndTime {get; init;}
}