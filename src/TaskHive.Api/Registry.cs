using TaskHive.Application;
using TaskHive.Infrastructure;

namespace TaskHive.Api
{
    public static class Registry
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            // for development purposes, we can use the environment variable to determine the environment
            // todo: find better solution for determining the environment
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
                                    ?? builder.Configuration.GetConnectionString("TaskHiveDbConnection")
                                    ?? throw new InvalidOperationException("Connection string not found.");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Connection string not found.");
            }

            services.RegisterInfrastructure(
                builder.Environment.EnvironmentName,
                connectionString);
            services.RegisterApplicationServices();
            return services;
        }
    }
}