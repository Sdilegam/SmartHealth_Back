using System.Security.Cryptography;
using System.Text;
using IntermediateLab_Backend.Application.Interfaces.Security;
using SmartHealth_Application.DTOs.Login;
using SmartHealth_Application.Interfaces.Repositories;
using SmartHealth_Application.Interfaces.Services;
using SmartHealth_Domain.Entities;
using SmartHealth_Domain.Enums;

namespace IntermediateLab_Backend.Application.Services;

public class AuthService(IAuthRepository authRepository,ITokenManager tokenManager, IDoctorRepository doctorRepository, IPatientRepository patientRepository):IAuthService
{
    public string Login(LoginFormDTO LoginDTO)
    {
        Login? user = authRepository.FindOneWhere(l=>l.Username == LoginDTO.Username);
        RolesEnum role;
        string name;
        if (user is null)
            throw new Exception("Les informations de connection ne sont pas correctes");
        if(Encoding.UTF8.GetString(SHA512.HashData(Encoding.UTF8.GetBytes(LoginDTO.Password + user.SaltKey))) != user.Password)
        { // 400 // 401
            throw new Exception("Les informations de connection ne sont pas correctes");
        }
        Doctor? doctor = doctorRepository.FindOneWhere(d => d.Login == user);
        role = doctor == null?RolesEnum.Patient:RolesEnum.Doctor;
        if (doctor is null)
        {
            Patient patient = patientRepository.FindOneWhere(p => p.Login == user);
            name = patient.FirstName + " " + patient.LastName;
        }
        else name= "Dr. " + doctor.LastName;
        string tokenToReturn = tokenManager.GenerateToken(user.LoginID,  name, role);
        return tokenToReturn;
    }

    public string refreshToken(string token)
    {
        int id = tokenManager.validateTokenWithoutLifetime(token);
        Login? user = authRepository.GetByID(id);
        string name;
        RolesEnum role;
        if (user is null)
        {
            throw new Exception();
        }
        Doctor? doctor = doctorRepository.FindOneWhere(d => d.Login == user);
        role = doctor == null?RolesEnum.Patient:RolesEnum.Doctor;
        if (doctor is null)
        {
            Patient patient = patientRepository.FindOneWhere(p => p.Login == user);
            name = patient.FirstName + " " + patient.LastName;;
        }
        else name= "dr " + doctor.FirstName +  " " + doctor.LastName;
        string newToken = tokenManager.GenerateToken(user.LoginID,  name, role);
        return (newToken);
    }
}
