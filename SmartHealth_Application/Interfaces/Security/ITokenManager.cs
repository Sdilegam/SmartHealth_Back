using SmartHealth_Domain.Enums;

namespace IntermediateLab_Backend.Application.Interfaces.Security;

public interface ITokenManager
{
    string GenerateToken(int id, string name, RolesEnum role);
    int validateTokenWithoutLifetime(string token);
}