using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHealth_Application.Interfaces.Repositories;
using SmartHealth_Application.Interfaces.Services;

namespace SmartHealth_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientController(IPatientService patientService): ControllerBase
{
    [HttpGet]
    [Authorize(Roles = "Patient")]
    public IActionResult GetPatientUserInfo()
    {
        return (Ok(patientService.GetPatientInfo(this.getId())));
    }
}