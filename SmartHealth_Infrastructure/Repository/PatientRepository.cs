using Microsoft.EntityFrameworkCore;
using SmartHealth_Application.Interfaces.Repositories;
using SmartHealth_Domain.Entities;

namespace SmartHealth_Infrastructure.Repository;

public class PatientRepository(SmartHealthContext context):BaseRepository<Patient>(context), IPatientRepository
{
    public Patient? GetPatientByLoginID(int loginID)
    {
        return context.Patients.Include(p=>p.Login).SingleOrDefault(patient => patient.Login.LoginID == loginID);
    }
}