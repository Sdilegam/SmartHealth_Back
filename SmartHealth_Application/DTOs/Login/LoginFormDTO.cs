using System.ComponentModel.DataAnnotations;

namespace SmartHealth_Application.DTOs.Login;

public record LoginFormDTO
{
    [Required]
    public string Username { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
};