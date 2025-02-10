using TaskHive.Application.Interfaces;
using TaskHive.Core.Projects;

namespace TaskHive.Infrastructure.Repositories
{
    public class InMemoryProjectRepository : IApplicationRepository<Project>
    {
        private readonly List<Project> _projects =
        [
            new() {
                Id = Guid.NewGuid(),
                Title = "project1",
                Description = "This is project 1",
                CreatedOn = new DateTime(2025, 4, 1, 0, 0, 0),
                DueDate = DateTime.Now
            },
            new() {
                Id = Guid.NewGuid(),
                Title = "project2",
                Description = "This is project 2",
                CreatedOn = new DateTime(2025, 4, 1, 0, 0, 0),
                DueDate = DateTime.Now
            }
        ];

        public Task<Project> GetProjectAsync(Guid id)
        {
            var project = _projects.FirstOrDefault(p => p.Id == id) ?? throw new KeyNotFoundException($"Project with id {id} not found.");
            return Task.FromResult(project);
        }

        public Task<IEnumerable<Project>> GetProjectsAsync()
        {
            return Task.FromResult(_projects.AsEnumerable());
        }

        public Task AddProjectAsync(Project project)
        {
            project.Id = Guid.NewGuid();
            _projects.Add(project);
            return Task.CompletedTask;
        }

        public Task UpdateProjectAsync(Project project)
        {
            var existingProject = _projects.FirstOrDefault(p => p.Id == project.Id) ?? throw new KeyNotFoundException($"Project with id {project.Id} not found.");
            _projects.Remove(existingProject);
            _projects.Add(project);
            return Task.CompletedTask;
        }

        public Task DeleteProjectAsync(Guid id)
        {
            var project = _projects.FirstOrDefault(p => p.Id == id) ?? throw new KeyNotFoundException($"Project with id {id} not found.");
            _projects.Remove(project);
            return Task.CompletedTask;
        }
    }
}