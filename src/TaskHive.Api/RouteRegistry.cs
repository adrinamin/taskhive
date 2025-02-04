using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskHive.Api.Projects.Models;
using TaskHive.Core.Projects;

namespace TaskHive.Api;

public static class RouteRegistry
{
    public static IEndpointRouteBuilder MapApiRoutes(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/projects", () =>
        {
            ProjectDto[] projects = [new ProjectDto("project1", "John", new DateTime(2025, 4, 1, 0, 0, 0), DateTime.Now)];

            return projects;
        });
        return routes;
    }

}