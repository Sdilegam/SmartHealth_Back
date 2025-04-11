using SmartHealth_Application.Interfaces.Repositories;
using SmartHealth_Domain.Entities;

namespace SmartHealth_Infrastructure.Repository;

public class DoctorRepository(SmartHealthContext context):BaseRepository<Doctor>(context), IDoctorRepository
{
    
}