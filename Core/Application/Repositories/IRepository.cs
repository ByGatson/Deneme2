using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Application.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<List<TEntity>> GetAll();
        Task<EntityEntry<TEntity>> AddAsync(TEntity entity);
        EntityEntry<TEntity> Update(TEntity entity);
        Task<EntityEntry<TEntity>> RemoveAsync(int id);
    }
}
