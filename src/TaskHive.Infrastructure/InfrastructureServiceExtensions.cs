using TaskHive.Application.Interfaces;
using TaskHive.Core.Projects;
using TaskHive.Infrastructure.Repositories;

namespace TaskHive.Infrastructure
{
    public static class InfrastructureServiceExtensions
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, string environment)
        {
            if (environment == "Development")
            {
                services.AddSingleton<IApplicationRepository<Project>, InMemoryProjectRepository>();
            }

            return services;
        }

    }
}