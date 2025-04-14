using Bogus.DataSets;
using Microsoft.AspNetCore.Mvc;
using SmartHealth_Application.DTOs.Doctor;
using SmartHealth_Application.Interfaces.Services;
using SmartHealth_Domain.Entities;

namespace SmartHealth_API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class DoctorController(IDoctorService doctorService): ControllerBase
{
    [HttpGet]
    [ProducesResponseType<DoctorListDTO[]>(StatusCodes.Status200OK, "application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Index([FromQuery] DoctorSearchDTO? searchDTO)
    {
        List<DoctorListDTO> doctorsToReturn = null!;
        
        doctorsToReturn = doctorService.GetAll(searchDTO);
        if (doctorsToReturn.Count == 0)
            return (NoContent());
        return (Ok(doctorsToReturn));
    }
}