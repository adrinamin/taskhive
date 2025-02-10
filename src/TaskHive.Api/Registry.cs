using TaskHive.Application;
using TaskHive.Infrastructure;

namespace TaskHive.Api
{
    public static class Registry
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.RegisterInfrastructure(builder.Environment.EnvironmentName);
            services.RegisterApplicationServices();
            return services;
        }
    }
}