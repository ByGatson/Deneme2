using Domain.Entities;
using Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Database.Context
{
    public class ECommerceDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public ECommerceDbContext(DbContextOptions options) : base(options)
        {
        }

        protected ECommerceDbContext()
        {
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Product>().HasOne(c => c.Company).WithMany(c => c.Products).HasForeignKey(p => p.CompanyId);
            builder.Entity<AppUser>().HasMany(a => a.Companies).WithOne(c => c.User).HasForeignKey(c => c.UserId);

            builder.Entity<Company>().HasMany(c => c.Customers)
                                     .WithMany(c => c.Companies)
                                     .UsingEntity(j => j.ToTable("CompanyCustomers"));
        }


    }
}
