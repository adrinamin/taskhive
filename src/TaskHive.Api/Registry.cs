using TaskHive.Application;
using TaskHive.Infrastructure;

namespace TaskHive.Api
{
    public static class Registry
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.RegisterInfrastructure();
            services.RegisterApplicationServices();
            return services;
        }
    }
}