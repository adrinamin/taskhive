using TaskHive.Application.Interfaces.Services;
using TaskHive.Application.Projects.Configuration;
using TaskHive.Application.Projects.Models;
using TaskHive.Application.Projects.Services;

namespace TaskHive.Application
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IProjectService<ProjectDto>, ProjectService>();
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            return services;
        }
    }
}