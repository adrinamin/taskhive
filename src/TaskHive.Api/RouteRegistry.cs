using TaskHive.Application.Interfaces.Services;
using TaskHive.Application.Projects.Models;

namespace TaskHive.Api;

public static class RouteRegistry
{
    public static IEndpointRouteBuilder MapApiRoutes(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/projects", (IProjectService<ProjectDto> projectService) =>
        {
            ProjectDto[] projects = [.. projectService.GetProjectsAsync().Result];
            return projects;
        });
        return routes;
    }

}