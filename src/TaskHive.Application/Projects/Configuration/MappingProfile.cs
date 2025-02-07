using TaskHive.Application.Projects.Models;
using TaskHive.Core.Projects;

namespace TaskHive.Application.Projects.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Project, ProjectDto>();
            CreateMap<ProjectDto, Project>();
        }
    }
}