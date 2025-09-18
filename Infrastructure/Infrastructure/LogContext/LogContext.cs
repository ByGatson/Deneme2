using Microsoft.EntityFrameworkCore;

namespace Infrastructure.LogContext
{
    public class LogContext : DbContext
    {
        public LogContext(DbContextOptions options) : base(options)
        {
        }

        protected LogContext()
        {
        }
    }
}
