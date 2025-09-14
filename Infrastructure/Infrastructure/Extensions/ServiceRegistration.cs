using Application.Interfaces.JwtToken;
using Application.Interfaces.Redis;
using Infrastructure.ExternalServices.JwtToken;
using Infrastructure.ExternalServices.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using System.Text;



namespace Persistence.Extensions
{
    public static class ServiceRegistration
    {

        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConnectionMultiplexer>(sp => ConnectionMultiplexer.Connect("localhost:6379"));
            services.AddScoped<ICacheService, RedisCacheService>();
            services.AddAuthentication()
            .AddJwtBearer(options => options.TokenValidationParameters = new()
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,


                ValidAudience = configuration["Token:Audience"],
                ValidIssuer = configuration["Token:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"] ?? ""))
            });
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}
