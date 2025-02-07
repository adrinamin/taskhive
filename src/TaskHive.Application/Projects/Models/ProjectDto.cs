namespace TaskHive.Application.Projects.Models;

public record ProjectDto(string title, string description, DateTime dueDate, DateTime createdOn);