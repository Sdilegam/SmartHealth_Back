using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHealth_Application.DTOs.Appointment;
using SmartHealth_Application.Interfaces.Services;

namespace SmartHealth_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MedecineController(IMedecineService medecineService): ControllerBase
{
    [Authorize(Roles = "Patient, Doctor")]
    [HttpGet("from-appointment/{appointmentID}")]
    public IActionResult AllMedecineFromAppointment([FromRoute] int appointmentID)
    {
        int userId = this.getId();
        return Ok(medecineService.AllFromAppointment(userId, appointmentID));
    }

    [Authorize(Roles = "Doctor")]
    [HttpPost("from-appointment/{appointmentID}")]
    public IActionResult CreateMedecineFromAppointment([FromRoute]int appointmentID, [FromBody] NewMedecineDTO medecineDTO)
    {
        int userId = this.getId();
        return (Ok(medecineService.AddFromAppointment(userId, appointmentID, medecineDTO)));
    }
}