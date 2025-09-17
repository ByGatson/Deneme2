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

            // Product - Company (1-N)
            builder.Entity<Product>()
                .HasOne(p => p.Company)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            // Product - Category (1-N)
            builder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);
            builder.Entity<AppUser>()
                .HasOne(u => u.Company)
                .WithOne(c => c.User)
                .HasForeignKey<AppUser>(u => u.CompanyId) // foreign key AppUser tarafında
                .OnDelete(DeleteBehavior.Cascade);



            // Company - Customer (N-M)
            builder.Entity<Company>()
                .HasMany(c => c.Customers)
                .WithMany(cu => cu.Companies)
                .UsingEntity(j => j.ToTable("CompanyCustomers"));

            // Basket - Product (N-M)
            builder.Entity<Basket>()
                .HasMany(b => b.Products)
                .WithMany(p => p.Baskets)
                .UsingEntity(j => j.ToTable("BasketProducts"));

            // Basket - AppUser (1-N)
            builder.Entity<Basket>()
                .HasOne(b => b.AppUser)
                .WithMany() // AppUser'da Basket collection yok, eğer istersen ekleyebilirsin
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            // Basket - Company (1-N)
            builder.Entity<Basket>()
                .HasOne(b => b.Company)
                .WithMany(c => c.Baskets)
                .HasForeignKey(b => b.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            // Customer - Basket (1-1 veya 1-N, senin yapına göre 1-1 gibi görünüyor)
            builder.Entity<Customer>()
                .HasOne(cu => cu.Basket)
                .WithMany() // Basket içinde collection zaten Products var
                .HasForeignKey(cu => cu.BasketId)
                .OnDelete(DeleteBehavior.SetNull);

            // Category - Company (1-N)
            builder.Entity<Category>()
                .HasOne(cat => cat.Company)
                .WithMany(c => c.Categories)
                .HasForeignKey(cat => cat.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
        }



    }
}
