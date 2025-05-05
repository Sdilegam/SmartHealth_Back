using SmartHealth_Application.DTOs.Medecine;
using SmartHealth_Domain.Entities;

namespace SmartHealth_Application.Mappers;

public static class MedecineMapper
{
    public static MedecineListDTO ToMedecineListDTO(this Medecine entity)
    {
        return new MedecineListDTO()
        {
            instructions = entity.Instructions,
            isBought = entity.isBought,
            name = entity.Name,
            medecineID = entity.MedecineID,
            quantity = entity.Quantity
        };
    }
}