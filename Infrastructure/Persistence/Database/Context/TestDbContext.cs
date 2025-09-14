using Microsoft.EntityFrameworkCore;

namespace Persistence.Database.Context
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions options) : base(options)
        {
        }

        protected TestDbContext()
        {
        }
    }
}
