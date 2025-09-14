using Application.Repositories;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Persistence.Database.Context;

namespace Persistence.Database.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly TestDbContext _context;

        public Repository(TestDbContext context)
        {
            _context = context;
        }

        private DbSet<TEntity> Table => _context.Set<TEntity>();
        public async Task<List<TEntity>> GetAll() => await Table.ToListAsync();
        public async Task<EntityEntry<TEntity>> AddAsync(TEntity entity) => await Table.AddAsync(entity);
        public async Task<EntityEntry<TEntity>> RemoveAsync(int id)
        {
            var user = await Table.FindAsync(id);
            var result = Table.Remove(user);
            return result;
        }
        public EntityEntry<TEntity> Update(TEntity entity) => Table.Update(entity);
    }
}
