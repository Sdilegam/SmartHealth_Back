using System.ComponentModel.DataAnnotations;

namespace SmartHealth_Domain.Entities;

public record Login
{
    public int LoginID { get; init; }
    public string Username { get; init; } = null!;
    public string Password { get; init; } = null!;
    public string Email { get; init; } = null!;
};