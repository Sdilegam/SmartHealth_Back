using SmartHealth_Application.DTOs.Login;

namespace SmartHealth_Application.Interfaces.Services;

public interface IAuthService
{
    public string Login(LoginFormDTO LoginDTO);
    public string refreshToken(string token);
}