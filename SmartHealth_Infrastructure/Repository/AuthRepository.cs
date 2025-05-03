using SmartHealth_Application.Interfaces.Repositories;
using SmartHealth_Domain.Entities;

namespace SmartHealth_Infrastructure.Repository;

public class AuthRepository(SmartHealthContext context): BaseRepository<Login>(context),  IAuthRepository
{
    public Patient? getPatientFromLogin(int loginID)
    {
        return (context.Patients.SingleOrDefault(p=>p.Login.LoginID == loginID));
    }

    public Doctor? getDoctorFromLogin(int loginID)
    {
        return (context.Doctors.SingleOrDefault(p=>p.Login.LoginID == loginID));
    }
}