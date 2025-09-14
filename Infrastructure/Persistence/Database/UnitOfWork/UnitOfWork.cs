using Application.UnitOfWork;
using Persistence.Database.Context;

namespace Persistence.Database.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public TestDbContext _context;

        public UnitOfWork(TestDbContext context)
        {
            _context = context;
        }

        public void Dispose() => _context.Dispose();
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken) => await _context.SaveChangesAsync();
    }
}
