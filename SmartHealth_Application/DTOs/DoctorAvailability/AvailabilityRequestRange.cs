namespace SmartHealth_Application.DTOs.DoctorAvailability;

public record AvailabilityRequestRange
{
    public DateTime start {get; init;}
    public DateTime end {get; init;}
}