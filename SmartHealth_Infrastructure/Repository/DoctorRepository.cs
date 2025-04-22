using Microsoft.EntityFrameworkCore;
using SmartHealth_Application.DTOs.DoctorAvailability;
using SmartHealth_Application.Interfaces.Repositories;
using SmartHealth_Domain.Entities;
using SmartHealth_Domain.Enums;

namespace SmartHealth_Infrastructure.Repository;

public class DoctorRepository(SmartHealthContext context) : BaseRepository<Doctor>(context), IDoctorRepository
{
    public Doctor? GetDoctorByIDWithAvailability(int ID)
    {
        return (context.Doctors.Include(doctor => doctor.Availability).FirstOrDefault(d => d.DoctorId == ID));
    }

    public Doctor? GetDoctorByIDWithAppointments(int ID)
    {
        return (context.Doctors.Include(doctor => doctor.Appointments).FirstOrDefault(d => d.DoctorId == ID));
    }

    public List<WorkingHoursDTO> GetAvailabilityList(int id, AvailabilityRequestRange range)
    {
        Doctor? doctor = GetDoctorByIDWithAvailability(id);
        List<WorkingHoursDTO> availabilityList = new();
        DateTime start = range.start.Date;
        IEnumerable<DoctorAvailability> availabilityQuery = null!;
        int firstDay = DateTime.Today.Date > start.Date ? (int)(DateTime.Today.Date - start.Date).TotalDays + 1 : 1;
        for (int i = firstDay; i <= 7; i++)
        {
            DateTime CurrDate = start.AddDays(i - 1);
            availabilityQuery = doctor.Availability.Where(a =>
                a.ValidtyStart <= CurrDate && (a.ValidtyEnd is null || a.ValidtyEnd > CurrDate));
            availabilityQuery = availabilityQuery.Where(a => a.Days.HasFlag((DaysOfWeekEnum) (1 << (i-1))))
                .Where(a=>a.EndTime > TimeOnly.FromDateTime(DateTime.Now));
            availabilityList.AddRange(availabilityQuery.Select(a => new WorkingHoursDTO
                {
                    DaysOfWeek = [i],
                    EndTime = a.EndTime.ToString("HH:mm"), 
                    StartTime = ((CurrDate.Date == DateTime.Today && (a.StartTime < TimeOnly.FromDateTime(DateTime.Now) && TimeOnly.FromDateTime(DateTime.Now) < a.EndTime)) ? TimeOnly.FromDateTime(DateTime.Now).AddHours(2) : a.StartTime).ToString("HH:mm")
                })
                .ToList());
            // availabilityList.AddRange(availabilityQuery.Select(a=>new AvailabilityReturnDTO{DaysOfWeek = [i], EndTime = $"18:00", StartTime = $"07:00"}).ToList());
        }

        return availabilityList;
    }

    public List<SlotsTaken> GetSlotsTaken(int id, AvailabilityRequestRange range)
    {
        Doctor? doctor = GetDoctorByIDWithAppointments(id);
        List<SlotsTaken> slotsList = new();
        DateTime start = range.start.Date;
        DateTime end = range.end.Date;
        for (DateTime d = start.Date; d < end.Date; d = d.AddDays(1))
        {
            List<Appointment> appList = doctor.Appointments.Where(a => a.StartTime.Date == d).OrderBy(a => a.StartTime)
                .ToList();
            slotsList.AddRange(SlotsTakenPerDay(appList));
        }

        return slotsList;
    }

    private List<SlotsTaken> SlotsTakenPerDay(List<Appointment> list)
    {
        List<SlotsTaken> slotList = new();
        if (list.Count == 0)
        {
            return slotList;
        }

        DateTime start = list[0].StartTime;
        DateTime end = list[0].StartTime.AddMinutes(list[0].Duration.TotalMinutes);
        bool added = true;
        foreach (Appointment item in list)
        {
            if (added == true)
            {
                start = list[0].StartTime;
                end = list[0].StartTime.AddMinutes(list[0].Duration.TotalMinutes);
                added = false;
            }

            if (item.StartTime <= end.AddMinutes(15)) end = item.StartTime.AddMinutes(item.Duration.TotalMinutes);
            else
            {
                slotList.Add(new SlotsTaken { EndDate = end.AddMinutes(5), StartDate = start.AddMinutes(-5), ClassNames = ["DoctorBusyBG"] });
                added = true;
            }
        }

        if (!added) slotList.Add(new SlotsTaken { EndDate = end.AddMinutes(5), StartDate = start.AddMinutes(-5), ClassNames = ["DoctorBusyBG"] });
        return slotList;
    }
}