using System.ComponentModel.DataAnnotations;

namespace TaskHive.Application.Projects.Models;

public record ProjectDto(
    Guid? Id,
    [Required]
    [StringLength(200, MinimumLength = 1)]
    string Title,
    [StringLength(1000)]
    string? Description,
    DateTime? DueDate,
    DateTime? CreatedOn);