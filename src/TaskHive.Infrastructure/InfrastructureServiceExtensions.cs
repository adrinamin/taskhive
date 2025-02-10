using TaskHive.Application.Interfaces;
using TaskHive.Core.Projects;
using TaskHive.Infrastructure.Repositories;

namespace TaskHive.Infrastructure
{
    public static class InfrastructureServiceExtensions
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IApplicationRepository<Project>, InMemoryProjectRepository>();

            return services;
        }

    }
}