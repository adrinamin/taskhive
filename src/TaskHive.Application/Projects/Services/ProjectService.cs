using TaskHive.Application.Interfaces;
using TaskHive.Application.Projects.Models;
using TaskHive.Core.Projects;

namespace TaskHive.Application.Projects.Services
{
    internal class ProjectService : IApplicationService<ProjectDto>
    {
        private readonly IApplicationRepository<Project> _projectRepository;
        private readonly IMapper _mapper;

        public ProjectService(IMapper mapper, IApplicationRepository<Project> projectRepository)
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

        public async Task AddProjectAsync(ProjectDto dto)
        {
            var project = _mapper.Map<Project>(dto);
            await _projectRepository.AddProjectAsync(project);
        }

        public async Task UpdateProjectAsync(ProjectDto dto)
        {
            var project = _mapper.Map<Project>(dto);
            await _projectRepository.UpdateProjectAsync(project);
        }

        public async Task DeleteProjectAsync(Guid id)
        {
            await _projectRepository.DeleteProjectAsync(id);
        }
    }
}