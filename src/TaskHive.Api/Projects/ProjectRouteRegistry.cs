using TaskHive.Application.Interfaces;
using TaskHive.Application.Projects.Models;

namespace TaskHive.Api.Projects;

public static class ProjectRouteRegistry
{
    public static IEndpointRouteBuilder MapProjectApiRoutes(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/projects", (IApplicationService<ProjectDto> projectService) =>
        {
            ProjectDto[] projects = [.. projectService.GetProjectsAsync().Result];
            return projects;
        });

        routes.MapGet("/projects/{id}", (IApplicationService<ProjectDto> projectService, Guid id) =>
        {
            ProjectDto project = projectService.GetProjectAsync(id).Result;
            return project;
        });

        routes.MapPost("/projects", (IApplicationService<ProjectDto> projectService, ProjectDto project) =>
        {
            projectService.AddProjectAsync(project);
            return Results.Created();
        });

        routes.MapPut("/projects/{id}", (IApplicationService<ProjectDto> projectService, Guid id, ProjectDto project) =>
        {
            projectService.UpdateProjectAsync(project);
            return Results.Accepted();
        });

        routes.MapDelete("/projects/{id}", (IApplicationService<ProjectDto> projectService, Guid id) =>
        {
            projectService.DeleteProjectAsync(id);
            return Results.NoContent();
        });

        return routes;
    }

}