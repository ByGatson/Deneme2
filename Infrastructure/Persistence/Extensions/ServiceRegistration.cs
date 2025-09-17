using Application.Repositories;
using Application.UnitOfWork;
using Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Database.Context;
using Persistence.Database.Repositories;
using Persistence.Database.UnitOfWork;



namespace Persistence.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ECommerceDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<ECommerceDbContext>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            //services.AddDbContext<TestDbContext>(options => options.UseMySql(configuration.GetConnectionString("MySQLConnection"), new MySqlServerVersion("8,0,0")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
