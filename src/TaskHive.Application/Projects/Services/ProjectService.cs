using TaskHive.Application.Interfaces.Repositories;
using TaskHive.Application.Interfaces.Services;
using TaskHive.Application.Projects.Models;
using TaskHive.Core.Projects;

namespace TaskHive.Application.Projects.Services
{
    internal class ProjectService : IProjectService<ProjectDto>
    {
        private readonly IProjectRepository<Project> _projectRepository;
        private readonly IMapper _mapper;

        public ProjectService(IMapper mapper, IProjectRepository<Project> projectRepository)
        {
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this._projectRepository = projectRepository ?? throw new ArgumentNullException(nameof(projectRepository));
        }

        public async Task<IEnumerable<ProjectDto>> GetProjectsAsync()
        {
            var projects = await _projectRepository.GetProjectsAsync();
            return _mapper.Map<IEnumerable<ProjectDto>>(projects);
        }

        public async Task<ProjectDto> GetProjectAsync(Guid id)
        {
            var project = await _projectRepository.GetProjectAsync(id);
            return _mapper.Map<ProjectDto>(project);
        }
    }
}