using System.Linq.Expressions;

namespace SmartHealth_Application.Interfaces.Repositories;

public interface IRepositoryBase<TEntity> where TEntity : class
{
    List<TEntity> GetAll();
    IQueryable<TEntity> GetAllQueryable();
    TEntity? GetByID(int id);
    TEntity? FindOneWhere(Expression<Func<TEntity, bool>> predicate);
}