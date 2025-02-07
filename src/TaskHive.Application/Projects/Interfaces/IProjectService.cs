using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskHive.Application.Interfaces.Services
{
    public interface IProjectService<T> where T : class
    {
        Task<IEnumerable<T>> GetProjectsAsync();
        Task<T> GetProjectAsync(Guid id);
        // Task<ProjectDto> CreateProjectAsync(ProjectDto project);
        // Task<ProjectDto> UpdateProjectAsync(Guid id, ProjectDto project);
        // Task DeleteProjectAsync(Guid id);
    }
}