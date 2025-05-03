using SmartHealth_Domain.Enums;

namespace SmartHealth_Application.DTOs.Appointment;

public record NewAppointmentDTO
{
    public DateTime Start { get; init; }
    public int Duration { get; init; }
    public AppointmentTypeEnum AppointmentType { get; set; }
}