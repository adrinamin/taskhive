namespace TaskHive.Application.Interfaces;

public interface IApplicationRepository<T> where T : class
{
    Task<IEnumerable<T>> GetProjectsAsync();

    Task<T> GetProjectAsync(Guid id);

    Task AddProjectAsync(T project);

    Task UpdateProjectAsync(T project);

    Task DeleteProjectAsync(Guid id);
}