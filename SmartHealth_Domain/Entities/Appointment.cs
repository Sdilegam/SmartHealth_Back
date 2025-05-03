using SmartHealth_Domain.Enums;

namespace SmartHealth_Domain.Entities;

public record Appointment
{
    public int AppointmentID { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public Doctor Doctor { get; set; } = null!;
    public Patient Patient { get; set; } = null!;
    public AppointmentTypeEnum Type { get; set; }
    public AppointmentStatusEnum Status { get; set; }
    public DateTime? RealStartTime { get; set; }
    public DateTime? RealEndTime { get; set; }
    public string PatientsNotes { get; set; } = "";
    public string DoctorsNotes { get; set; } = "";
};