using SmartHealth_Application.Interfaces.Repositories;
using SmartHealth_Domain.Entities;

namespace SmartHealth_Infrastructure.Repository;

public class AuthRepository(SmartHealthContext context): BaseRepository<Login>(context),  IAuthRepository
{
    
}