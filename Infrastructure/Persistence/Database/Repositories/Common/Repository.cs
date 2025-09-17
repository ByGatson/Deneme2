using Application.Exceptions;
using Application.Repositories;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Persistence.Database.Context;

namespace Persistence.Database.Repositories.Common
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ECommerceDbContext _context;

        public Repository(ECommerceDbContext context)
        {
            _context = context;
        }

        private DbSet<TEntity> Table => _context.Set<TEntity>();
        public async Task<List<TEntity>> GetAll() => await Table.ToListAsync();
        public async Task<EntityEntry<TEntity>> AddAsync(TEntity entity) => await Table.AddAsync(entity);
        public async Task<EntityEntry<TEntity>> RemoveAsync(string id)
        {
            var entity = await Table.FindAsync(id);
            if (entity is null) throw new EntityIsNotFoundException();
            var result = Table.Remove(entity);
            return result;
        }
        public EntityEntry<TEntity> Update(TEntity entity) => Table.Update(entity);

        public async Task<TEntity> FindByIdAsync(string id)
        {
            var entity = await Table.FindAsync(id);
            if (entity is null) throw new EntityIsNotFoundException();
            return entity;
        }

    }
}
