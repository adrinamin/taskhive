namespace TaskHive.Application.Interfaces;

public interface IApplicationService<T> where T : class
{
    Task<IEnumerable<T>> GetProjectsAsync();

    Task<T> GetProjectAsync(Guid id);

    Task AddProjectAsync(T dto);

    Task UpdateProjectAsync(T dto);

    Task DeleteProjectAsync(Guid id);
}