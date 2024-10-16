using HAHN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HAHN.Infrastructure
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddDependecyInjectionInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Database Context
            services.AddDbContext<HahnDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("Database")));

            return services;
        }
    }
}
