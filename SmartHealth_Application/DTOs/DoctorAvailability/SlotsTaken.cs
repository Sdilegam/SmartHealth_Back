namespace SmartHealth_Application.DTOs.DoctorAvailability;

public record SlotsTaken
{
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
}