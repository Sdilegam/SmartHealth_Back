using Microsoft.AspNetCore.Mvc;
using SmartHealth_Application.Interfaces.Repositories;

namespace SmartHealth_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientController(IPatientRepository repository): ControllerBase
{
    [HttpGet]
    public IActionResult getAllPatients()
    {
        return Ok(repository.GetAll());
    }
}