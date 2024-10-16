using HAHN.Domain.Interfaces;
using HAHN.Infrastructure.Data;
using HAHN.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HAHN.Infrastructure
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddDependecyInjectionInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Repositories
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ITicketRepository, TicketRepository>();

            // Database Context
            services.AddDbContext<HahnDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("Database")));

            return services;
        }
    }
}
