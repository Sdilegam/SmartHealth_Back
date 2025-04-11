using SmartHealth_Application.DTOs.Address;
using SmartHealth_Application.DTOs.Doctor;
using SmartHealth_Domain.Entities;

namespace SmartHealth_Application.Mappers;

public static class AddressMapper
{
    public static AddressDTO ToDTO(this Address entity)
    {
        AddressDTO DTOToReturn = new()
        {
            Number =  entity.Number,
            Street =  entity.Street,
            City =  entity.City,
            Zip = entity.Zip,
            Country =  entity.Country
        };
        return DTOToReturn;
    } 
}