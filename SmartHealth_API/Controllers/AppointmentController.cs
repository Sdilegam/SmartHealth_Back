using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHealth_Application.DTOs.Appointment;
using SmartHealth_Application.Interfaces.Services;
using SmartHealth_Domain.Entities;

namespace SmartHealth_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentController(IAppointmentService appointmentService):ControllerBase
{
    [HttpGet()]
    [Authorize]
    public IActionResult GetAll()
    {
        List<AppointmentListDTO> appointmentsToReturn = null!;
        int userID = this.getId();
        
        appointmentsToReturn = appointmentService.GetAll(userID, User.FindFirst(ClaimTypes.Role).Value);
        if (appointmentsToReturn.Count == 0)
            return (NoContent());
        return (Ok(appointmentsToReturn));
    }

    [HttpGet("{appointmentID}")]
    [Authorize]
    public IActionResult GetAppointmentDetails([FromRoute] int appointmentID)
    {
        int userID = this.getId();
        AppointmentDetailsDTO DTOToReturn = null!;
        try
        {
            DTOToReturn = appointmentService.getAppointmentDetails(appointmentID, userID);

        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }

        if (DTOToReturn is null) return (NotFound());
        return (Ok(DTOToReturn));
    }
    
    [Authorize(Roles = "Patient")]
    [HttpPost("{doctorID}/newAppointment")]
    public IActionResult CreateApppointment([FromRoute]int doctorID, [FromBody] NewAppointmentDTO appointment)
    {
        int patientID = this.getId();
        Appointment appointmentToReturn = null!;
        try
        {
           appointmentToReturn =  appointmentService.CreateAppointment(patientID, doctorID, appointment);
        }
        catch (Exception e)
        {
           return NotFound(e.Message);
        }
        return Ok(appointment);
    }

    [Authorize(Roles = "Patient")]
    [HttpDelete("{appointmentID}/cancel")]
    public IActionResult CancelAppointment([FromRoute] int appointmentID)
    {
        int patientID = this.getId(); //TODO: Change ID handling
        try
        {
            appointmentService.cancelAppointment(patientID,  appointmentID);
            return Ok();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}