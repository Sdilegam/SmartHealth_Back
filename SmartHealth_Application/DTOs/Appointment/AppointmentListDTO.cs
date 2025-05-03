using SmartHealth_Domain.Enums;

namespace SmartHealth_Application.DTOs.Appointment;

public record AppointmentListDTO
{
    public int appointmentID { get; init; }
    public string startDate { get; init; }
    public string endDate { get; init; }
    public AppointmentTypeEnum type { get; init; }
    public AppointmentStatusEnum status { get; init; }
    public Doctor doctor { get; init; }
    public record Doctor
    {
        public int doctorID { get; init; }
        public string name { get; init; }
    }
};