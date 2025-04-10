namespace SmartHealth_Application.Interfaces.Repositories;

public interface IRepositoryBase<TEntity> where TEntity : class
{
    List<TEntity> GetAll();
}