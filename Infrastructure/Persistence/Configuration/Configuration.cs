using Microsoft.Extensions.Configuration;

namespace ETicaretAPI.Persistence.Configurations
{
    static class Configuration
    {
        public static string? ConfigurationString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ETicaretAPI.API"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetConnectionString("PostgreSQL");
            }
        }
    }
}
