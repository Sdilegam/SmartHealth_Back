using SmartHealth_Domain.Entities;

namespace SmartHealth_Application.Interfaces.Repositories;

public interface IAuthRepository: IRepositoryBase<Login>
{
    public Patient? getPatientFromLogin(int loginID);
    public Doctor? getDoctorFromLogin(int loginID);
}