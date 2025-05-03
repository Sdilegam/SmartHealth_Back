using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SmartHealth_Application.Interfaces.Repositories;

namespace SmartHealth_Infrastructure.Repository;

public class BaseRepository<TEntity>(SmartHealthContext context): IRepositoryBase<TEntity> where TEntity : class
{
    protected SmartHealthContext Context { get; } = context;

    protected DbSet<TEntity> Entities => this.Context.Set<TEntity>();
    
    public virtual List<TEntity> GetAll()
    {
        return (this.Entities.ToList());
    }

    public virtual TEntity? GetByID(int id) => this.Entities.Find(id);
    public TEntity? FindOneWhere(Expression<Func<TEntity, bool>> predicate)
    {
        return this.Entities.FirstOrDefault(predicate);
    }

    public virtual IQueryable<TEntity> GetAllQueryable()
    {
        return (this.Entities);
    }
}