using SmartHealth_Application.DTOs.Doctor;
using SmartHealth_Application.DTOs.DoctorAvailability;
using SmartHealth_Application.Interfaces.Repositories;
using SmartHealth_Application.Interfaces.Services;
using SmartHealth_Application.Mappers;
using SmartHealth_Domain.Entities;
using SmartHealth_Domain.Enums;

namespace SmartHealth_Application.Services;

public class DoctorService(IDoctorRepository doctorRepository):IDoctorService
{
    public List<DoctorListDTO> GetAll(DoctorSearchDTO? searchDTO)
    {
        IQueryable<Doctor> doctorsQueryable = doctorRepository.GetAllQueryable();
        if (searchDTO == null) return doctorsQueryable.Select(x=>x.ToDoctorListDTO(x.Telecoms.FirstOrDefault().TelecomValue, null)).ToList();
        if (searchDTO.Multi != null)
        {
            doctorsQueryable = doctorsQueryable.Where(doctor=>doctor.FirstName.Contains(searchDTO.Multi) ||
                                                              doctor.LastName.Contains(searchDTO.Multi)||
                                                              doctor.ProfessionalAddress.Zip.Contains(searchDTO.Multi));
            
        }

        if (searchDTO.Name != null)
        {
            doctorsQueryable = doctorsQueryable.Where(doctor => doctor.FirstName.Contains(searchDTO.Name)||
                                                                doctor.LastName.Contains(searchDTO.Name));
        }

        if (searchDTO.Zipcode != null)
        {
            doctorsQueryable = doctorsQueryable.Where(doctor => doctor.ProfessionalAddress.Zip.Contains(searchDTO.Zipcode));
        }
        // doctorListToReturn = doctorRepository.GetAll();
        return doctorsQueryable.Select(
            x=> x.ToDoctorListDTO(x.Telecoms.FirstOrDefault(t=>t.Type == TelecomsTypeEnum.EmailAddress).TelecomValue,
                x.Telecoms.FirstOrDefault(t=>t.Type == TelecomsTypeEnum.PhoneNumber).TelecomValue)).ToList();
    }

    public AvailabilityReturnDTO GetAvailability(int id, AvailabilityRequestRange range)
    {
        List<WorkingHoursDTO> availabilityList = doctorRepository.GetAvailabilityList(id, range);
        List<SlotsTaken> slotsList = doctorRepository.GetSlotsTaken(id, range);

        return (new AvailabilityReturnDTO{WorkingHours=availabilityList,SlotsTaken=slotsList});
    }
}