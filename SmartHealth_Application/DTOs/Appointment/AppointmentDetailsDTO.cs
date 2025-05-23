﻿using SmartHealth_Domain.Enums;

namespace SmartHealth_Application.DTOs.Appointment;

public record AppointmentDetailsDTO
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
    public Patient patient { get; init; }

    public record Patient
    {
        public int patientID { get; init; }
        public string name { get; init; }
    }
    public string creationDate { get; set; }
    public string? realStartTime { get; set; }
    public string? realEndTime { get; set; }
    public string patientsNotes { get; set; }
    public string doctorsNotes { get; set; }
}