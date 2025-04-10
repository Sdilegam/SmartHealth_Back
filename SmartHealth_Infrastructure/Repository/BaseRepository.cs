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
        // return (new List<TEntity>());
    }
}