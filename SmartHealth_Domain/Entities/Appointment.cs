using SmartHealth_Domain.Enums;

namespace SmartHealth_Domain.Entities;

public record Appointment
{
    public int AppointmentID { get; init; }
    public DateTime StartTime { get; init; }
    public TimeSpan Duration { get; init; }
    public Doctor Doctor { get; init; } = null!;
    public Patient Patient { get; init; } = null!;
    public AppointmentTypeEnum Type { get; init; }
    public AppointmentStatusEnum Status { get; init; }
    public string PatientsNotes { get; init; } = "";
};