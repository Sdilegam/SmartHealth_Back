using System.ComponentModel.DataAnnotations;
using SmartHealth_Domain.Enums;

namespace SmartHealth_Domain.Entities;

public record Login
{
    public int LoginID { get; init; }
    public string Username { get; init; } = null!;
    public string Password { get; init; } = null!;
    public string Email { get; init; } = null!;
    public Guid SaltKey { get; init; }
    public RolesEnum Role { get; init; }
};