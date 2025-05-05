using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHealth_Application.DTOs.Doctor;
using SmartHealth_Application.DTOs.DoctorAvailability;
using SmartHealth_Application.Interfaces.Services;

namespace SmartHealth_API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class DoctorController(IDoctorService doctorService): ControllerBase
{
    [HttpGet("index")]
    [Produces<DoctorListDTO[]>()]
    // [ProducesResponseType<DoctorListDTO[]>(StatusCodes.Status200OK, "application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Index([FromQuery] DoctorSearchDTO? searchDTO)
    {
        List<DoctorListDTO> doctorsToReturn = null!;
        
        doctorsToReturn = doctorService.GetAll(searchDTO);
        if (doctorsToReturn.Count == 0)
            return (NoContent());
        return (Ok(doctorsToReturn));
    }

    [HttpPost("{id}/availability")]
    [ProducesResponseType<List<AvailabilityReturnDTO>>(StatusCodes.Status200OK, "application/json")]
    public IActionResult Availability([FromRoute] int id, [FromBody] AvailabilityRequestRange range)
    {
        AvailabilityReturnDTO availabilityReturn = null!;
        availabilityReturn = doctorService.GetAvailability(id, range);
        return (Ok(availabilityReturn));
    }
    
    [HttpGet]
    [Authorize(Roles = "Doctor")]
    public IActionResult GetPatientUserInfo()
    {
        return (Ok(doctorService.GetDoctorInfo(this.getId())));
    }
}