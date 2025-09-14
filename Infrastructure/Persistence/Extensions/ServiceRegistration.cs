using Application.UnitOfWork;
using ETicaretAPI.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Database.Context;
using Persistence.Database.UnitOfWork;



namespace Persistence.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<TestDbContext>(options => options.UseNpgsql(Configuration.ConfigurationString));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
