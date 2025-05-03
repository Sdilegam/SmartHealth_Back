using Microsoft.AspNetCore.Mvc;
using SmartHealth_Application.DTOs.Login;
using SmartHealth_Application.Interfaces.Services;

namespace SmartHealth_API.Controllers;

[Route("api")]
[ApiController]
public class AuthController(IAuthService authService): ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginFormDTO loginDTO)
    {
        try
        {
            string tokenToReturn = authService.Login(loginDTO);
            return Ok(new {Token = tokenToReturn});
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("refreshToken")]
    public IActionResult RefreshToken([FromQuery]string token)
    {
        string tokenToReturn = null!;
        try
        {
            tokenToReturn = authService.refreshToken(token);

        }
        catch (Exception e)
        {
            return Unauthorized();
        }
        return Ok( new {Token = tokenToReturn});
    }
}