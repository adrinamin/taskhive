using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskHive.Application.Interfaces;
using TaskHive.Core.Projects;
using TaskHive.Infrastructure.Data;

namespace TaskHive.Infrastructure.Repositories
{
    public class SqlProjectRepository : IApplicationRepository<Project>
    {
        private readonly ProjectDbContext _dbContext;

        public SqlProjectRepository(ProjectDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task AddProjectAsync(Project project)
        {
            await _dbContext.Projects.AddAsync(project);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProjectAsync(Guid id)
        {
            var project = await _dbContext.Projects.FindAsync(id);
            if (project != null)
            {
                _dbContext.Projects.Remove(project);
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Project> GetProjectAsync(Guid id)
        {
            var project = await _dbContext.Projects.FindAsync(id)
            ?? throw new KeyNotFoundException($"Project with id {id} not found");
            return project;
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            return await _dbContext.Projects.ToListAsync();
        }

        public async Task UpdateProjectAsync(Project project)
        {
            _dbContext.Projects.Update(project);
            await _dbContext.SaveChangesAsync();
        }
    }
}