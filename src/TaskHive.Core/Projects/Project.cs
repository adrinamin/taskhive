namespace TaskHive.Core.Projects;
public class Project
{
    public Guid Id;

    public required string Title { get; set; }

    public required string Description { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime DueDate { get; set; }
}