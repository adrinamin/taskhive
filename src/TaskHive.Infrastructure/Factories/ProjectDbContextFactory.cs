using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using TaskHive.Infrastructure.Data;

namespace TaskHive.Infrastructure.Factories
{
    /// <summary>
    /// Factory for creating a new instance of the ProjectDbContext.
    /// This is used by the EF Core tools to create migrations.
    /// </summary>
    public class ProjectDbContextFactory : IDesignTimeDbContextFactory<ProjectDbContext>
    {
        public ProjectDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddEnvironmentVariables()
                .Build();

            var connectionString = config["DB_CONNECTION_STRING"];

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Connection string not found.");
            }

            var optionsBuilder = new DbContextOptionsBuilder<ProjectDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ProjectDbContext(optionsBuilder.Options);
        }
    }
}