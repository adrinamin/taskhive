using Microsoft.EntityFrameworkCore;
using TaskHive.Application.Interfaces;
using TaskHive.Core.Projects;
using TaskHive.Infrastructure.Data;
using TaskHive.Infrastructure.Repositories;

namespace TaskHive.Infrastructure
{
    public static class InfrastructureServiceExtensions
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, string environment, string connectionString)
        {
            if (environment == "Local")
            {
                services.AddSingleton<IApplicationRepository<Project>, InMemoryProjectRepository>();
            }
            else if (environment == "Development")
            {
                Console.WriteLine($"Resolved Connection String: {connectionString}");
                services.AddDbContext<ProjectDbContext>(options =>
                    options.UseSqlServer(connectionString));
                services.AddScoped<IApplicationRepository<Project>, SqlProjectRepository>();
            }

            return services;
        }

    }
}