using Microsoft.EntityFrameworkCore;
using SmartHealth_Application.Interfaces.Repositories;
using SmartHealth_Domain.Entities;

namespace SmartHealth_Infrastructure.Repository;

public class PatientRepository(SmartHealthContext context):BaseRepository<Patient>(context), IPatientRepository
{
   
}