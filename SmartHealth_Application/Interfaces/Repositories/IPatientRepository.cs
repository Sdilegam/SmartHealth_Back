using SmartHealth_Domain.Entities;

namespace SmartHealth_Application.Interfaces.Repositories;

public interface IPatientRepository :IRepositoryBase<Patient>
{
    public Patient? GetPatientByLoginID(int loginID);

}